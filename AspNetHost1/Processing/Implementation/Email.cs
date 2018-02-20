using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace AspNetHost1.Processing.Implementation
{
    public class EmailWriter : ILogWriter
    {
        public void LogMessage(string message)
        {
            MailMessage mail = new MailMessage("muralidharan.pushpakaran@hotmail.com.com", "wax.murali@gmail.com");
            SmtpClient client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com"
            };
            mail.Subject = "Log";
            mail.Body = message;
            client.Send(mail);
        }
    }
}