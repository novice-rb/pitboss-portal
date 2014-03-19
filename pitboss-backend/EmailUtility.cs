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

        public EmailUtility(string smtpServer, int portNumber, string userName, string password, string domain, int waitTimeBetweenSends)
        {
            _waitTimeBetweenSends = waitTimeBetweenSends;
            _smtpClient = new SmtpClient(smtpServer, portNumber);
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            if(!string.IsNullOrEmpty(userName)) {
                if (string.IsNullOrEmpty(domain))
                {
                    _smtpClient.Credentials = new NetworkCredential(userName, password);
                }
                else
                {
                    _smtpClient.Credentials = new NetworkCredential(userName, password, domain);
                }
            }
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
