using ExpenseManagement.Repository.DataAccess;
using ExpenseManagement.Repository.Model.DataModel;
using ExpenseManagement.Repository.Model.EntityModel;
using Newtonsoft.Json;

namespace ExpenseManagement.Repository.Service
{
    public class GroupExpenseService
    {
        private readonly GroupExpenseRepository _GroupExpenseRepo;
        private readonly GroupRepository _GroupRepo;
        private readonly ActivityRepository _ActivityRepo;

        public GroupExpenseService()
        {
            _GroupExpenseRepo = new GroupExpenseRepository();
            _GroupRepo = new GroupRepository();
            _ActivityRepo = new ActivityRepository();
        }

        public List<GroupExpense> GetAllGroupExpenses()
        {
            return _GroupExpenseRepo.GetAllGroupExpenses();
        }

        public List<GroupExpense> GetAllGroupExpensesForGroupId(short groupId)
        {
            return _GroupExpenseRepo.GetAllGroupExpensesForGroupId(groupId);
        }

        public GroupExpense GetGroupExpensesById(short groupExpenseId)
        {
            return _GroupExpenseRepo.GetGroupExpensesById(groupExpenseId);
        }

        public bool AddGroupExpense(GroupExpenseModel groupExpenseModel, short userId = 0)
        {
            bool result = _GroupExpenseRepo.AddGroupExpense(groupExpenseModel);
            var group = _GroupRepo.GetGroupById(groupExpenseModel.GroupId);

            var groupSplitModel = JsonConvert.DeserializeObject<AmountSplitModel>(group.MemberAmount);
            groupSplitModel ??= new AmountSplitModel { Splits = [] };

            decimal totalPaid = 0;
            foreach (var expenseSplit in groupExpenseModel.IndividualSplitJson.Splits)
            {
                var grpSplit = groupSplitModel.Splits.FirstOrDefault(gs => gs.UserId == expenseSplit.UserId);
                if (grpSplit == null)
                {
                    grpSplit = new Split
                    {
                        UserId = expenseSplit.UserId,
                        UserName = expenseSplit.UserName
                    };
                    groupSplitModel.Splits.Add(grpSplit);
                }
                grpSplit.AmountPaid = expenseSplit.AmountPaid;
                totalPaid += expenseSplit.AmountPaid;
                group.Total += expenseSplit.AmountPaid;
                grpSplit.DueAmount += expenseSplit.DueAmount;
            }

            group.MemberAmount = JsonConvert.SerializeObject(groupSplitModel);
            result = result & _GroupRepo.UpdateGroupExpense(group);

            //Notify
            //Add to activity 
            _ActivityRepo.AddActivity(new ActivityModel()
            {
                 GroupId= group.Id,
                 UserId = userId,
                 CreatedOn = DateTime.Now,
                 Message= $"Added new expense - {groupExpenseModel.Description} of total amount {totalPaid}"
            });

            return result;
        }

        public bool EditGroupExpense(GroupExpenseModel newGroupExpenseModel, short userId = 0)
        {
            var existingGrouppExpense = _GroupExpenseRepo.GetGroupExpensesById(newGroupExpenseModel.Id);
            bool result = _GroupExpenseRepo.EditGroupExpense(newGroupExpenseModel);
            var group = _GroupRepo.GetGroupById(newGroupExpenseModel.GroupId);

            var existingGroupExpenseSplitModel = JsonConvert.DeserializeObject<AmountSplitModel>(existingGrouppExpense.IndividualSplit);
            var groupSplitModel = JsonConvert.DeserializeObject<AmountSplitModel>(group.MemberAmount);

            foreach (var expenseSplit in newGroupExpenseModel.IndividualSplitJson.Splits)
            {
                var grpSplit = groupSplitModel.Splits.FirstOrDefault(gs => gs.UserId == expenseSplit.UserId);
                var existingGrpExpenseUserSplit = existingGroupExpenseSplitModel.Splits.FirstOrDefault(gs => gs.UserId == expenseSplit.UserId);

                if (existingGrpExpenseUserSplit != null && grpSplit != null)
                {
                    grpSplit.AmountPaid -= existingGrpExpenseUserSplit.AmountPaid;
                    group.Total -= existingGrpExpenseUserSplit.AmountPaid;
                    grpSplit.DueAmount -= existingGrpExpenseUserSplit.DueAmount;
                }

                if (grpSplit != null && expenseSplit !=null)
                {
                    grpSplit.AmountPaid += expenseSplit.AmountPaid;
                    group.Total += expenseSplit.AmountPaid;
                    grpSplit.DueAmount += expenseSplit.DueAmount;
                }
            }
            group.MemberAmount = JsonConvert.SerializeObject(groupSplitModel);

            result = result & _GroupRepo.UpdateGroupExpense(group);

            //Notify
            //Add to activity 
            string editMgs = string.Empty;
            if (existingGrouppExpense.Description != newGroupExpenseModel.Description)
                editMgs = $"Description Modified.\n\t Previous Value : {existingGrouppExpense.Description}.\n\t New Value :{newGroupExpenseModel.Description}\n\n";

            List<Split> largeSet = JsonConvert.DeserializeObject<AmountSplitModel>(existingGrouppExpense.IndividualSplit).Splits;
            List<Split> smallSet = newGroupExpenseModel.IndividualSplitJson.Splits;

            if(smallSet.Count > largeSet.Count)
            {
                smallSet = largeSet;
                largeSet = newGroupExpenseModel.IndividualSplitJson.Splits;
            }
            
            foreach (var split1 in largeSet)
            {
                Split split2 = smallSet.FirstOrDefault(a =>a.UserId == split1.UserId);
                if(split2 == null)
                {
                    editMgs = $"{editMgs}Added or Removed user.\n\t UserName : {split2.UserName}\n\n";
                }
                else
                {
                    if(split1.AmountPaid != split2.AmountPaid)
                        editMgs = $"{editMgs} Updated spending amount for user.\n\t UserName : {split2.UserName}\n\n";

                //    if (split1.AmountPaid != split2.AmountPaid)
                //        editMgs = $"{editMgs} Updated spending amount for user.\n\t UserName : {split2.UserName}\n\n";
                }
            }

            _ActivityRepo.AddActivity(new ActivityModel()
            {
                GroupId = group.Id,
                UserId = userId,
                CreatedOn = DateTime.Now,
                Message = $"Edited expense - {editMgs}"
            });
            return result;
        }

        public bool DeleteGroupExpense(short groupExpenseId, short userId=0)
        {
            var groupExpense = _GroupExpenseRepo.GetGroupExpensesById(groupExpenseId);
            bool result = _GroupExpenseRepo.DeleteGroupExpense(groupExpenseId);
            var group = _GroupRepo.GetGroupById(groupExpense.GroupId);

            var groupExpenseSplitModel = JsonConvert.DeserializeObject<AmountSplitModel>(groupExpense.IndividualSplit);
            var groupSplitModel = JsonConvert.DeserializeObject<AmountSplitModel>(group.MemberAmount);

            decimal totalPaid = 0;
            foreach (var expenseSplit in groupExpenseSplitModel.Splits)
            {
                var grpSplit = groupSplitModel.Splits.FirstOrDefault(gs => gs.UserId == expenseSplit.UserId);
                if (grpSplit != null)
                {
                    grpSplit.AmountPaid -= expenseSplit.AmountPaid;
                    group.Total -= expenseSplit.AmountPaid;
                    totalPaid += expenseSplit.AmountPaid;
                    grpSplit.DueAmount -= expenseSplit.DueAmount;
                }
            }
            group.MemberAmount = JsonConvert.SerializeObject(groupSplitModel);

            result = result & _GroupRepo.UpdateGroupExpense(group);

            //Notify
            //Add to activity 
            _ActivityRepo.AddActivity(new ActivityModel()
            {
                GroupId = group.Id,
                UserId = userId,
                CreatedOn = DateTime.Now,
                Message = $"Deleted expense - {groupExpense.Description} of total amount {totalPaid}"
            });
            return result;
        }
    }
}
