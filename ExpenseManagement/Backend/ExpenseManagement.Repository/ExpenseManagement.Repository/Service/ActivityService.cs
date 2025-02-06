using ExpenseManagement.Repository.DataAccess;
using ExpenseManagement.Repository.Model.DataModel;
using ExpenseManagement.Repository.Model.EntityModel;

namespace ExpenseManagement.Repository.Service
{
    public class ActivityService
    {
        private readonly ActivityRepository _ActivityRepo;

        public ActivityService()
        {
            _ActivityRepo = new ActivityRepository();
        }

        public List<Activity> GetAllActivitys()
        {
            return _ActivityRepo.GetAllActivities();
        }

        public List<Activity> GetAllActivitiesRelatedToUser(short userId)
        {
            return _ActivityRepo.GetAllActivitiesRelatedToUser(userId);
        }

        public List<Activity> GetAllActivitiesRelatedToGroup(short groupId)
        {
            return _ActivityRepo.GetAllActivitiesRelatedToGroup(groupId);
        }

        public bool AddActivity(ActivityModel activityModel)
        {
            return _ActivityRepo.AddActivity(activityModel);
        }
    }
}
