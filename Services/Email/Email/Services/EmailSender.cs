using System;
using System.Threading.Tasks;
using Email.Common.Interfaces;
using Email.Common.Settings;
using Email.DTO;
using EventBus.Enums;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Email.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly MailSettings _mailConfig;
        private readonly IRazorViewToString _razorViewToString;

        public EmailSender(MailSettings mailConfig, IRazorViewToString razorViewToString)
        {
            _mailConfig = mailConfig ?? throw new ArgumentNullException(nameof(mailConfig));
            _razorViewToString = razorViewToString ?? throw new ArgumentNullException(nameof(razorViewToString));
        }

        public async Task SendEmailAsync(EmailDTO emailDTO)
        {
            var body = await _razorViewToString.RenderViewToStringAsync("Views/Register.cshtml", emailDTO);

            var subject = emailDTO.EmailType switch
            {
                EmailType.Register => "Register on eShop!",
                _ => throw new ArgumentOutOfRangeException()
            };

            await SendEmail(emailDTO.Email, subject, body);
        }

        private async Task SendEmail(string email, string subject, string message)
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
                await client.AuthenticateAsync(_mailConfig.EmailAddress, _mailConfig.Password);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}