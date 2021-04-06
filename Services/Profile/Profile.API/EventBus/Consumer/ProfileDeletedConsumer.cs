using System;
using System.Threading.Tasks;
using EventBus.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using Profile.API.Common.Interfaces;
using Serilog.Core;

namespace Profile.API.EventBus.Consumer
{
    public class ProfileDeletedConsumer : IConsumer<IProfileDeleted>
    {
        private readonly IProfileService _profileService;
        private readonly ILogger<ProfileDeletedConsumer> _logger;

        public ProfileDeletedConsumer(IProfileService profileService, ILogger<ProfileDeletedConsumer> logger)
        {
            _profileService = profileService ?? throw new ArgumentNullException(nameof(profileService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Consume(ConsumeContext<IProfileDeleted> context)
        {
            try
            {
                _logger.LogInformation("Start profile deleted consumer");

                var userId = context.Message.UserId;
                var success = await _profileService.DeleteProfileByIdAsync(userId);
                _logger.LogInformation($"{success}");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }       
        }
    }
}