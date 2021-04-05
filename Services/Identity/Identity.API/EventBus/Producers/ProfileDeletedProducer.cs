using System;
using System.Threading.Tasks;
using EventBus.Common;
using EventBus.Events;
using MassTransit;

namespace Identity.EventBus.Producers
{
    public class ProfileDeletedProducer : IEventProducer<IProfileDeleted, int>
    {
        private readonly IBusControl _bus;

        /// <summary>
        /// Constructor of producer for "user deleted" events.
        /// </summary>
        /// <param name="bus">Event bus.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ProfileDeletedProducer(IBusControl bus)
        {
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));
        }
        
        public async Task<bool> Publish(int userId)
        {
            try
            {
                await _bus.Publish<IProfileDeleted>(new
                {
                    CommandId = Guid.NewGuid(),
                    UserId = userId,
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