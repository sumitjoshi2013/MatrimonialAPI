using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

/*
 * 
    Yahoo!	smtp.mail.yahoo.com	587	Yes
    GMail	smtp.gmail.com	587	Yes
    Hotmail	smtp.live.com	587	Yes
 * 
 */

namespace Helper
{
    public class Utility
    {
        public bool MailSend(string emailTo, string subject, string body)
        {
            string smtpAddress = "smtp.mail.yahoo.com";
            int portNumber = 587;
            bool enableSSL = true;
            bool flag = true;
            string emailFrom = "email@yahoo.com";
            string password = "abcdefg";
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(emailTo);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception exp)
            {
                flag = false;
            }

            return flag;
        }
    }
}
