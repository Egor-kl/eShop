using System;
using System.Threading.Tasks;
using EventBus.Common;
using EventBus.DTO;
using EventBus.Events;
using MassTransit;
using Serilog;

namespace Identity.EventBus.Producers
{
    public class CreateProfileProducer : IEventProducer<IRegisterProfile, IUserDTO>
    {
        private readonly IBusControl _bus;
        private readonly ILogger _logger;

        public CreateProfileProducer(ILogger logger, IBusControl bus)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));
        }

        public async Task<bool> Publish(IUserDTO data)
        {
            try
            {
                _logger.Information($"Start create profile producer with user id = {data.Id}");

                await _bus.Publish<IRegisterProfile>(new
                {
                    CommandId = Guid.NewGuid(),
                    UserId = data.Id,
                    Email = data.Email,
                    UserName = data.UserName,
                    CreationDate = DateTime.Now.ToString("G")
                });
                
                _logger.Information($"End create profile producer with user id = {data.Id}");
            }
            catch (Exception e)
            {
                _logger.Error($"{e.Message}");
                return false;
            }

            return true;
        }
    }
}