using System;
using System.Threading.Tasks;
using EventBus.Events;
using MassTransit;
using Profile.API.Common.Interfaces;
using Serilog.Core;

namespace Profile.API.EventBus.Consumer
{
    public class ProfileDeletedConsumer : IConsumer<IProfileDeleted>
    {
        private readonly IProfileService _profileService;
        private readonly Logger _logger;

        public ProfileDeletedConsumer(IProfileService profileService, Logger logger)
        {
            _profileService = profileService ?? throw new ArgumentNullException(nameof(profileService));
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<IProfileDeleted> context)
        {
            try
            {
                var userId = context.Message.UserId;
                var success = await _profileService.DeleteProfileByIdAsync(userId);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }       
        }
    }
}