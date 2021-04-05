using System;
using System.Threading.Tasks;
using EventBus.Common;
using EventBus.DTO;
using EventBus.Events;
using MassTransit;

namespace Profile.API.EventBus.Producers
{
    public class UserDeletedProducer : IEventProducer<IUserDeleted, IUserDTO>
    {
        private readonly IBusControl _bus;

        /// <summary>
        /// Constructor of producer for user deletion events.
        /// </summary>
        /// <param name="bus">Event bus.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserDeletedProducer(IBusControl bus)
        {
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));
        }
        
        /// <inheritdoc/>
        public async Task<bool> Publish(IUserDTO userDTO)
        {
            try
            {
                await _bus.Publish<IUserDeleted>(new
                {
                    CommandId = Guid.NewGuid(),
                    ProfileId = userDTO.ProfileId,
                    UserId = userDTO.UserId,
                    CreationDate = DateTime.Now,
                });

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }
    }
}