using ExpenseManagement.Repository.Model.DataModel;
using ExpenseManagement.Repository.Service;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.SettingsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailSettingController : ControllerBase
    {
        private readonly ILogger<EmailSettingController> _logger;

        public EmailSettingController(ILogger<EmailSettingController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetAllEmailSettings")]
        public Task GetAllEmailSettings()
        {
            EmailSettingService emailSettingService = new();
            emailSettingService.GetAllEmailSettings();
            return Task.CompletedTask;
        }

        [HttpGet("GetEmailSettingByUserId")]
        public Task GetEmailSettingById(short userId)
        {
            EmailSettingService emailSettingService = new();
            emailSettingService.GetEmailSettingByUserId(userId);
            return Task.CompletedTask;
        }

        [HttpPost("AddEmailSetting")]
        public Task AddEmailSetting(EmailSettingModel emailSettingModel)
        {
            EmailSettingService emailSettingService = new();

            emailSettingService.AddEmailSetting(emailSettingModel);
            return Task.CompletedTask;
        }

        [HttpPost("EditEmailSetting")]
        public Task EditEmailSetting(EmailSettingModel emailSettingModel)
        {
            EmailSettingService emailSettingService = new();
            emailSettingService.EditEmailSetting(emailSettingModel);
            return Task.CompletedTask;
        }

        [HttpDelete("DeleteEmailSetting")]
        public Task DeleteEmailSetting(short userId)
        {
            EmailSettingService emailSettingService = new();
            emailSettingService.DeleteEmailSetting(userId);
            return Task.CompletedTask;
        }
    }
}
