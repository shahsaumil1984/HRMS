using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;

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
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        }

        public static void SendEmailToEmployee(string Subject, string Body, string FromAddress, string FromUser, string ToAddress, string ToUser,string attachment)
        {
            Task<Response> response;
            try
            {
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["SendEmail"]))
                {
                    var apiKey = ConfigurationManager.AppSettings["SendGrid"];
                    var client = new SendGridClient(apiKey);
                    var from = new EmailAddress(FromAddress, FromUser);
                    var subject = Subject;
                    var to = new EmailAddress(ToAddress, ToUser);
                    //var plainTextContent = "and easy to do anywhere, even with C#";
                    var htmlContent = Body;
                    var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
                    msg.AddAttachment("SalarySlip.pdf", attachment);
                    response =  client.SendEmailAsync(msg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}