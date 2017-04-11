using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.Serialization;
namespace HRMS
{
    public class Helper
    {
        public enum EmployeeStatus
        {
            Active = 1,
            Probation,

            [EnumMember(Value = "Notice Period")]
            NoticePeriod,

            [EnumMember(Value = "In Active")]
            InActive
        };

        public enum SalaryStatus
        {
            Pending = 1,
            Approved

        };

        public enum Month
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            November,
            December,
        }

        public static void SendEmailToEmployee(List<Personalization> listPersonalization, string Subject, string Body, string FromAddress)
        {
            try
            {
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["sendEmail"]))
                {
                    //Environment.SetEnvironmentVariable("APIKey", ConfigurationManager.AppSettings["SendGrid"], EnvironmentVariableTarget.User);
                    string apiKey = ConfigurationManager.AppSettings["SendGrid"];//Environment.GetEnvironmentVariable("APIKey", EnvironmentVariableTarget.User);
                    dynamic sg = new SendGrid.SendGridAPIClient(apiKey, Convert.ToString(ConfigurationManager.AppSettings["SendGridURL"]));

                    Mail mail = new Mail();
                    SendGrid.Helpers.Mail.Email email = new SendGrid.Helpers.Mail.Email();

                    email.Address = FromAddress;
                    mail.From = email;
                    mail.Subject = Subject;
                    mail.Personalization = listPersonalization;

                    Content content = new Content();
                    content = new Content();
                    content.Type = "text/html";
                    content.Value = Body;
                    mail.AddContent(content);
                    sg.client.mail.send.post(requestBody: mail.Get());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}