using System;
using System.Threading.Tasks;
using EventBus.Events;
using MassTransit;
using Profile.API.Common.Interfaces;

namespace Profile.API.EventBus.Consumer
{
    public class RegisterProfileConsumer : IConsumer<IProfileCreate>
    {
        private readonly IProfileService _service;

        public RegisterProfileConsumer(IProfileService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }


        public async Task Consume(ConsumeContext<IProfileCreate> context)
        {
            var profileDTO = context.Message.ProfileDTO;
            var success = await _service.RegisterNewProfileAsync(profileDTO);
        }
    }
}