using ExpenseManagement.Repository.Model.DataModel;
using ExpenseManagement.Repository.Model.EntityModel;
using ExpenseManagement.Repository.Model.EntityModel.Context;

namespace ExpenseManagement.Repository.DataAccess
{
    internal class EmailSettingRepository
    {
        internal List<EmailSetting> GetAllEmailSettings()
        {
            try
            {
                List<EmailSetting> emailSettings = new();
                using var context = new ExpenseManagementContext();
                emailSettings = context.EmailSettings.ToList<EmailSetting>();

                return emailSettings;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        internal EmailSetting GetEmailSettingByUserId(short userId)
        {
            try
            {
                EmailSetting emailSetting = new();
                using var context = new ExpenseManagementContext();
                emailSetting = context.EmailSettings.First(u => u.UserId == userId);

                return emailSetting;
            }
            catch (Exception)
            {

                return null;
            }
        }

        internal bool AddEmailSetting(EmailSettingModel emailSettingModel)
        {
            try
            {
                using var context = new ExpenseManagementContext();
                var existingEmailSetting = context.EmailSettings.First(eSetting => eSetting.UserId == emailSettingModel.UserId);
                if (existingEmailSetting == null)
                {
                    EmailSetting emailSetting = new()
                    {
                        UserId = emailSettingModel.UserId,
                        Questions = emailSettingModel.Questions
                    };

                    context.EmailSettings.Add(emailSetting);
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

        internal bool EditEmailSetting(EmailSettingModel emailSettingModel)
        {
            try
            {
                using var context = new ExpenseManagementContext();
                var existingEmailSetting = context.EmailSettings.First(eSetting => eSetting.UserId == emailSettingModel.UserId);
                if (existingEmailSetting != null)
                {
                    existingEmailSetting.Questions = emailSettingModel.Questions;

                    context.EmailSettings.Update(existingEmailSetting);
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

        internal bool DeleteEmailSetting(short userId)
        {
            try
            {
                using var context = new ExpenseManagementContext();
                var existingEmailSetting = context.EmailSettings.First(u => u.UserId == userId);
                if (existingEmailSetting != null)
                {
                    context.EmailSettings.Remove(existingEmailSetting);
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
