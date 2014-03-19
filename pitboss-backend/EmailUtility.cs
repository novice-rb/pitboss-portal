using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace pitboss_backend
{
    public class EmailUtility
    {
        private SmtpClient _smtpClient;
        private int _waitTimeBetweenSends;

        public EmailUtility(int waitTimeBetweenSends)
        {
            _waitTimeBetweenSends = waitTimeBetweenSends;
            _smtpClient = new SmtpClient();
        }

        public void SendEmails(string fromAddress, IEnumerable<string> recipientAddresses, string subject, string bodyHtml)
        {
            foreach (var recipient in recipientAddresses)
            {
                MailAddress fromMail = new MailAddress(fromAddress);
                MailAddress toMail = new MailAddress(recipient);
                MailMessage email = new MailMessage(fromMail, toMail);
                email.IsBodyHtml = true;
                email.Subject = subject;
                email.Body = bodyHtml;
                _smtpClient.Send(email);
                System.Threading.Thread.Sleep(_waitTimeBetweenSends);
            }
        }

    }
    
}
