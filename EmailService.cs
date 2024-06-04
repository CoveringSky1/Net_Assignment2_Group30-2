using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
     class EmailService
    {
        private readonly string sender = "qinghe.lin064@gmail.com";
        MailMessage mail = new MailMessage();
        private readonly string token = "qlwbxjdykkxbpsuc";
        SmtpClient smtpClient = new SmtpClient();
        private readonly string host = "smtp.gmail.com";
        private readonly int port = 587;
        private readonly Boolean enableSsl = true;



        public string sendEmail(string subject, string content, string to)
        {
            mail.From = new MailAddress(sender);
            
            mail.To.Add(new MailAddress(to));
            mail.Subject = subject;
            mail.Body = content;
            mail.IsBodyHtml = true;
            smtpClient.Host = host;
            smtpClient.Port = port;
            smtpClient.EnableSsl = enableSsl;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new NetworkCredential(sender, token);
            try
            {
                smtpClient.Send(mail);
                return "Send Email send succesfully";
            }catch (Exception ex)
            {
                return "Fail to send email" + ex.Message;
            }
        }
        


    }
}
