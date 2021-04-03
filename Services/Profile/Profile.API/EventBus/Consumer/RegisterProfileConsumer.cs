using System;
using System.Threading.Tasks;
using EventBus.Commands;
using MassTransit;
using Profile.API.Common.Interfaces;

namespace Profile.API.EventBus.Consumer
{
    public class RegisterProfileConsumer : IConsumer<IRegisterProfile>
    {
        private readonly IProfileService _service;

        public RegisterProfileConsumer(IProfileService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }


        public async Task Consume(ConsumeContext<IRegisterProfile> context)
        {
            var profileDTO = context.Message.User;
            var success = await _service.RegisterNewProfileAsync(profileDTO);
        }
    }
}