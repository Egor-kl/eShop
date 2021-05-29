using System;
using System.Linq;
using System.Threading.Tasks;
using EventBus.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using Profile.API.Common.Interfaces;
using Profile.API.DTO;

namespace Profile.API.EventBus.Consumer
{
    public class CreateProfileConsumer : IConsumer<IRegisterProfile>
    {
        private readonly IProfileContext _context;
        private readonly ILogger<ProfileDeletedConsumer> _logger;
        private readonly IProfileService _profileService;

        public CreateProfileConsumer(IProfileService profileService, ILogger<ProfileDeletedConsumer> logger,
            IProfileContext context)
        {
            _profileService = profileService ?? throw new ArgumentNullException(nameof(profileService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context;
        }

        public async Task Consume(ConsumeContext<IRegisterProfile> context)
        {
            try
            {
                _logger.LogInformation("Start profile deleted consumer");

                var UserId = _context.Profiles.Max(x => x.Id) + 1;
                var UserName = context.Message.UserName;
                var CreationDate = context.Message.CreationDate;
                var Email = context.Message.Email;

                var profileDTO = new ProfileDTO
                {
                    UserId = UserId,
                    UserName = UserName,
                    Email = Email
                };

                var success = await _profileService.RegisterNewProfileAsync(profileDTO);
                _logger.LogInformation($"{success}");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}