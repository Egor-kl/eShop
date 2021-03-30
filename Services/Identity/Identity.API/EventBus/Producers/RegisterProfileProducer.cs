using System;
using System.Threading.Tasks;
using EventBus.Common;
using EventBus.Events;
using Identity.DTO;
using MassTransit;

namespace Identity.EventBus.Producers
{
    public class RegisterProfileProducer : IEventProducer<IProfileCreate, UserDTO>
    {
        private readonly IBusControl _busControl;
        
        public RegisterProfileProducer(IBusControl busControl)
        {
            _busControl = busControl ?? throw new ArgumentNullException(nameof(busControl));
        }
        /// <inheritdoc/>
        public async Task<bool> Publish(UserDTO userDTO)
        {
            await _busControl.Publish<IProfileCreate>(new
            {
                UserId = userDTO.Id,
                Email = userDTO.Email,
                UserName = userDTO.UserName
            });

            return true;
        }
    }
}