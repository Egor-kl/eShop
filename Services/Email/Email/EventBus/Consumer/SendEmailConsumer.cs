using System;
using System.Threading.Tasks;
using Email.Common.Interfaces;
using Email.DTO;
using EventBus.Events;
using MassTransit;

namespace Email.EventBus.Consumer
{
    public class SendEmailConsumer : IConsumer<ISendEmail>
    {
        private readonly IEmailSender _sendEmail;

        public SendEmailConsumer(IEmailSender sendEmail)
        {
            _sendEmail = sendEmail ?? throw new ArgumentNullException(nameof(sendEmail));
        }

        public async Task Consume(ConsumeContext<ISendEmail> context)
        {
            try
            {
                Console.WriteLine("start send email");
                var email = new EmailDTO
                {
                    Email = context.Message.Email,
                    EmailType = context.Message.EmailType,
                    UserName = context.Message.UserName
                };

                await _sendEmail.SendEmailAsync(email);
                Console.WriteLine($"End send email {email.Email} - {email.EmailType} - {email.UserName}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}