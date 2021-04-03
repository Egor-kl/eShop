using System;
using System.Threading.Tasks;
using EventBus.Commands;
using EventBus.Common;
using EventBus.DTO;
using MassTransit;

namespace Identity.EventBus.Producers
{
    public class RegisterProfileProducer : ICommandProducer<IRegisterProfile, IUserDTO>
    {
        private readonly IBusControl _busControl;
        
        public RegisterProfileProducer(IBusControl busControl)
        {
            _busControl = busControl ?? throw new ArgumentNullException(nameof(busControl));
        }

        public async Task<bool> Send(IUserDTO data)
        {
            await _busControl.Send<IRegisterProfile>(new
            {
                CommandId = Guid.NewGuid(),
                ProfileDTO = data,
                CreationDate = DateTime.Now,
            });

            return true;
        }
    }
}