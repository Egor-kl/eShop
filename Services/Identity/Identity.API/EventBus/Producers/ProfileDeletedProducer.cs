using System;
using System.Threading.Tasks;
using EventBus.Common;
using EventBus.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Identity.EventBus.Producers
{
    public class ProfileDeletedProducer : IEventProducer<IProfileDeleted, int>
    {
        private readonly IBusControl _bus;
        private readonly ILogger<ProfileDeletedProducer> _logger;

        /// <summary>
        ///     Constructor of producer for "user deleted" events.
        /// </summary>
        /// <param name="bus">Event bus.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ProfileDeletedProducer(IBusControl bus, ILogger<ProfileDeletedProducer> logger)
        {
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Publish(int userId)
        {
            try
            {
                _logger.LogInformation($"Start identity profile deleted producer with user id = {userId}");

                await _bus.Publish<IProfileDeleted>(new
                {
                    CommandId = Guid.NewGuid(),
                    UserId = userId,
                    CreationDate = DateTime.Now
                });
            }
            catch (Exception e)
            {
                _logger.LogWarning($"{e.Message}");
                return false;
            }

            return true;
        }
    }
}