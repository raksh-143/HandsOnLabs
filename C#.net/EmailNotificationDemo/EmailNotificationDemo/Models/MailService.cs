using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using System.Threading.Tasks;
using Unity;

namespace EmailNotificationDemo.Models
{
    public class MailService:IMailService
    {
        [Dependency]
        private readonly MailSettings _mailSettings;
        public MailService()
        {

        }
        public MailService(MailSettings mailSettings)
        {
            _mailSettings = mailSettings;
        }

        public async Task SendEmailAsync(EmailSender Model)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_mailSettings.Mail));
            email.To.Add(MailboxAddress.Parse(Model.To));
            email.Subject = Model.Subject;
            //var builder = new BodyBuilder();
            email.Body = new TextPart("plain")
            {
                Text = Model.Body
            };
            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Mail,_mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
        }
    }
}