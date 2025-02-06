using ExpenseManagement.Repository.Model.DataModel;
using ExpenseManagement.Repository.Model.EntityModel;
using ExpenseManagement.Repository.Model.EntityModel.Context;

namespace ExpenseManagement.Repository.DataAccess
{
    internal class GroupRepository
    {
        internal List<Group> GetAllGroups()
        {
            try
            {
                List<Group> Groups = new();
                using var context = new ExpenseManagementContext();
                Groups = context.Groups.ToList<Group>();

                return Groups;
            }
            catch (Exception)
            {

                return null;
            }
        }

        internal Group GetGroupById(short groupId)
        {
            try
            {
                Group Group = new();
                using var context = new ExpenseManagementContext();
                Group = context.Groups.First(u => u.Id == groupId);

                return Group;
            }
            catch (Exception)
            {

                return null;
            }
        }

        internal bool AddGroup(GroupModel groupModel)
        {
            try
            {
                using var context = new ExpenseManagementContext();
                var existingGroup = context.Groups.FirstOrDefault(u => u.GroupName == groupModel.GroupName);
                if (existingGroup == null)
                {

                    Group Group = new()
                    {
                        GroupName = groupModel.GroupName,
                        Description = groupModel.Description,
                        GroupTypeId = groupModel.GroupTypeId,
                        Icon = groupModel.Icon,
                        CreatedBy = groupModel.CreatedBy,
                        AdminId = groupModel.AdminId,
                        MemberIds = groupModel.MemberIds,
                        Total = groupModel.Total,
                        MemberAmount = groupModel.MemberAmount,
                        IsActive = true
                    };

                    context.Groups.Add(Group);
                    context.SaveChanges();
                    return true;
                }
                else
                    return false; //Group exist
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        internal bool EditGroup(GroupModel groupModel)
        {
            try
            {
                using var context = new ExpenseManagementContext();
                var existingGroup = context.Groups.First(u => u.Id == groupModel.Id);
                if (existingGroup != null)
                {
                    existingGroup.GroupName = groupModel.GroupName;
                    existingGroup.Description = groupModel.Description;
                    existingGroup.GroupTypeId = groupModel.GroupTypeId;
                    existingGroup.Icon = groupModel.Icon;
                    existingGroup.CreatedBy = groupModel.CreatedBy;
                    existingGroup.AdminId = groupModel.AdminId;
                    existingGroup.MemberIds = groupModel.MemberIds;
                    existingGroup.Total = groupModel.Total;
                    existingGroup.MemberAmount = groupModel.MemberAmount;
                    existingGroup.IsActive = groupModel.IsActive;

                    context.Groups.Update(existingGroup);
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        internal bool UpdateGroupExpense(Group group)
        {
            try
            {
                using var context = new ExpenseManagementContext();
                var existingGroup = context.Groups.First(u => u.Id == group.Id);
                if (existingGroup != null)
                {
                    existingGroup.Total = group.Total;
                    existingGroup.MemberAmount = group.MemberAmount;

                    context.Groups.Update(existingGroup);
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        internal bool DeleteGroup(short id)
        {
            try
            {
                using var context = new ExpenseManagementContext();
                var existingGroup = context.Groups.First(u => u.Id == id);
                if (existingGroup != null)
                {
                    existingGroup.IsActive = false;
                    context.Groups.Update(existingGroup);
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
