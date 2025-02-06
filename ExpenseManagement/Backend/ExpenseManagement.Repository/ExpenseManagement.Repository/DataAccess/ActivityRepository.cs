using ExpenseManagement.Repository.Model.DataModel;
using ExpenseManagement.Repository.Model.EntityModel;
using ExpenseManagement.Repository.Model.EntityModel.Context;

namespace ExpenseManagement.Repository.DataAccess
{
    internal class ActivityRepository
    {
        internal List<Activity> GetAllActivities()
        {
            try
            {
                List<Activity> activities = new();
                using var context = new ExpenseManagementContext();
                activities = context.Activities.ToList<Activity>();

                return activities;
            }
            catch (Exception)
            {

                return null;
            }
        }

        internal List<Activity> GetAllActivitiesRelatedToUser(short userId)
        {
            try
            {
                List<Activity> activities = new();
                using var context = new ExpenseManagementContext();
                activities = context.Activities.Where(a=>a.UserId == userId).ToList<Activity>();

                return activities;
            }
            catch (Exception)
            {

                return null;
            }
        }

        internal List<Activity> GetAllActivitiesRelatedToGroup(short groupId)
        {
            try
            {
                List<Activity> activities = new();
                using var context = new ExpenseManagementContext();
                activities = context.Activities.Where(a => a.GroupId == groupId).ToList<Activity>();

                return activities;
            }
            catch (Exception)
            {

                return null;
            }
        }

        internal bool AddActivity(ActivityModel activityModel)
        {
            try
            {
                using var context = new ExpenseManagementContext();

                Activity user = new()
                {
                    UserId = activityModel.UserId,
                    CreatedOn = DateTime.Now,
                    GroupId = activityModel.GroupId,
                    Message = activityModel.Message
                };

                context.Activities.Add(user);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
