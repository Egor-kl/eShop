using System;
using System.Threading.Tasks;
using EventBus.Common;
using EventBus.DTO;
using EventBus.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Identity.EventBus.Producers
{
    public class SendEmailProducer : IEventProducer<ISendEmail, IEmailDTO>
    {
        private readonly IBusControl _bus;
        private readonly ILogger<SendEmailProducer> _logger;

        /// <summary>
        /// Constructor of producer for user deletion events.
        /// </summary>
        /// <param name="bus">Event bus.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SendEmailProducer(IBusControl bus, ILogger<SendEmailProducer> logger)
        {
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        /// <inheritdoc/>
        public async Task<bool> Publish(IEmailDTO emailDTO)
        {
            try
            {
                _logger.LogInformation("Start send email producer");
                await _bus.Publish<ISendEmail>(new
                {
                    CommandId = Guid.NewGuid(),
                    Email = emailDTO.Email,
                    UserName = emailDTO.UserName,
                    EmailType = emailDTO.EmailType,
                    CreationDate = DateTime.Now,
                });

            }
            catch (Exception e)
            {
                _logger.LogError($"{e.Message}");
                return false;
            }
            return true;
        }
    }
}