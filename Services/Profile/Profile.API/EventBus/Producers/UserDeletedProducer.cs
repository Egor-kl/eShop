using System;
using System.Threading.Tasks;
using EventBus.Common;
using EventBus.DTO;
using EventBus.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Profile.API.EventBus.Producers
{
    public class UserDeletedProducer : IEventProducer<IUserDeleted, IUserDTO>
    {
        private readonly IBusControl _bus;
        private readonly ILogger<UserDeletedProducer> _logger;

        /// <summary>
        /// Constructor of producer for user deletion events.
        /// </summary>
        /// <param name="bus">Event bus.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserDeletedProducer(IBusControl bus, ILogger<UserDeletedProducer> logger)
        {
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        /// <inheritdoc/>
        public async Task<bool> Publish(IUserDTO userDTO)
        {
            try
            {
                _logger.LogInformation("Start profile profile deleted producer");
                await _bus.Publish<IUserDeleted>(new
                {
                    CommandId = Guid.NewGuid(),
                    UserId = userDTO.Id,
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