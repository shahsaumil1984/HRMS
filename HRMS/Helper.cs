using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace HRMS
{
    public class Helper
    {
        public enum EmployeeStatus
        {
            Probation = 1,
            Active = 2,

            [EnumMember(Value = "Notice Period")]
            NoticePeriod = 3,


            Disassociated = 4,


            [EnumMember(Value = "Full And Final")]
            FullAndFinal = 5,

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

        public static bool SendEmailToEmployee(string Subject, string Body, string FromAddress, string FromUser, string ToAddress, string ToUser, string attachment)
        {
            bool isMailSent = false;
            try
            {
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["SendEmail"]))
                {
                    Task<Response> response;
                    var apiKey = ConfigurationManager.AppSettings["SendGrid"];
                    var client = new SendGridClient(apiKey);
                    var from = new EmailAddress(FromAddress, FromUser);
                    var subject = Subject;
                    var to = new EmailAddress(ToAddress, ToUser);
                    //var plainTextContent = "and easy to do anywhere, even with C#";
                    var htmlContent = Body;
                    var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
                    var BccTo = new EmailAddress(ConfigurationManager.AppSettings["BCCToEmail"], ConfigurationManager.AppSettings["BCCToUser"]);
                    msg.AddBcc(BccTo);
                    msg.AddAttachment("SalarySlip.pdf", attachment);
                    response = client.SendEmailAsync(msg);
                    isMailSent = true;
                }
                return isMailSent;
            }
            catch (Exception ex)
            {
                isMailSent = false;
                return isMailSent;
            }
        }

        public static byte[] CreatePDFFromHTMLFile(string HtmlStream)
        {
            try
            {
                string ModifiedFileName = string.Empty;
                string FinalFileName = string.Empty;

                var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                htmlToPdf.PageWidth = 280;
                htmlToPdf.PageHeight = 500;
                var pdfBytes = htmlToPdf.GeneratePdf(HtmlStream);
                return pdfBytes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ignoreEmployeeStatus = "EmployeeStatusID < 4 and IsDisabled == false";
        public static string ignoreEmployeeStatus1 = "Employee.EmployeeStatusID < 4 and Employee.IsDisabled == false";

        public static bool SendMail(string subject, string body, string from, string toList, byte[] attachment)
        {
            bool isMailSent = false;
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            string msg = string.Empty;
            try
            {
                MailAddress fromAddress = new MailAddress(from);
                message.From = fromAddress;
                message.To.Add(toList);
                string BccTo = ConfigurationManager.AppSettings["BCCToEmail"].ToString();
                MailAddress BCCAddress = new MailAddress(BccTo);
                message.Bcc.Add(BCCAddress);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = body;
                if (attachment != null)
                    message.Attachments.Add(new System.Net.Mail.Attachment(new MemoryStream(attachment), "SalarySlip.pdf"));
               
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                string gmailUserID = ConfigurationManager.AppSettings["gmailUserID"].ToString();
                string gmailPassword = ConfigurationManager.AppSettings["gmailPassword"].ToString();
                smtpClient.Credentials = new System.Net.NetworkCredential(gmailUserID, gmailPassword);
                smtpClient.Host = "smtp.gmail.com";   // We use gmail as our smtp client
                smtpClient.Port = 587;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Send(message);
                isMailSent = true;
            }
            catch (Exception ex)
            {
                isMailSent = false;
            }
            return isMailSent;
        }
    }
}