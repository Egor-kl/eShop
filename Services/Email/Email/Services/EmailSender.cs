using System;
using System.Threading.Tasks;
using Email.Common.Interfaces;
using Email.Common.Settings;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Email.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly MailSettings _mailConfig;

        public EmailSender(MailSettings mailConfig)
        {
            _mailConfig = mailConfig ?? throw new ArgumentNullException(nameof(mailConfig));
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("eShop ", _mailConfig.EmailAddress));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_mailConfig.Server, _mailConfig.Port, false);
                await client.AuthenticateAsync(_mailConfig.EmailAddress,_mailConfig.Password);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}