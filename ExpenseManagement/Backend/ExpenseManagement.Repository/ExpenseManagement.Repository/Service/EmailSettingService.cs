using ExpenseManagement.Repository.DataAccess;
using ExpenseManagement.Repository.Model.DataModel;
using ExpenseManagement.Repository.Model.EntityModel;

namespace ExpenseManagement.Repository.Service
{
    public class EmailSettingService
    {
        private readonly EmailSettingRepository _EmailSettingRepo;

        public EmailSettingService()
        {
            _EmailSettingRepo = new EmailSettingRepository();
        }

        public List<EmailSetting> GetAllEmailSettings()
        {
            return _EmailSettingRepo.GetAllEmailSettings();
        }

        public EmailSetting GetEmailSettingByUserId(short userId)
        {
            return _EmailSettingRepo.GetEmailSettingByUserId(userId);
        }

        public bool AddEmailSetting(EmailSettingModel emailSettingModel)
        {
            return _EmailSettingRepo.AddEmailSetting(emailSettingModel);
        }

        public bool EditEmailSetting(EmailSettingModel emailSettingModel)
        {
            return _EmailSettingRepo.EditEmailSetting(emailSettingModel);
        }

        public bool DeleteEmailSetting(short userId)
        {
            return _EmailSettingRepo.DeleteEmailSetting(userId);
        }
    }
}
