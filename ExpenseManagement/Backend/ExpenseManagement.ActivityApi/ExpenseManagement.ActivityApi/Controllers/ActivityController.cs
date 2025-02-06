using ExpenseManagement.Repository.Model.DataModel;
using ExpenseManagement.Repository.Service;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.ActivityApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly ILogger<ActivityController> _logger;

        public ActivityController(ILogger<ActivityController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetAllActivity")]
        public Task GetAllActivity()
        {
            ActivityService activityService = new();
            activityService.GetAllActivitys();
            return Task.CompletedTask;
        }

        [HttpGet("GetAllActivitiesRelatedToUser")]
        public Task GetAllActivitiesRelatedToUser(short userId)
        {
            ActivityService activityService = new();
            activityService.GetAllActivitiesRelatedToUser(userId);
            return Task.CompletedTask;
        }

        [HttpGet("GetAllActivitiesRelatedToGroup")]
        public Task GetAllActivitiesRelatedToGroup(short groupId)
        {
            ActivityService activityService = new();
            activityService.GetAllActivitiesRelatedToGroup(groupId);
            return Task.CompletedTask;
        }

        [HttpPost("AddActivity")]
        public Task AddActivity(ActivityModel activityModel)
        {
            ActivityService activityService = new();
            activityService.AddActivity(activityModel);
            return Task.CompletedTask;
        }
    }
}
