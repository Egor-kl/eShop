using System;
using System.Threading.Tasks;
using EventBus.Events;
using Identity.Common.Interfaces;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Identity.EventBus.Consumers
{
    public class UserDeletedConsumer : IConsumer<IUserDeleted>
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserDeletedConsumer> _logger;

        public UserDeletedConsumer(IUserService userService, ILogger<UserDeletedConsumer> logger)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Consume for user deleted
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Consume(ConsumeContext<IUserDeleted> context)
        {
            try
            {
                _logger.LogInformation("Start identity user deleted consumer");
                var userId = context.Message.UserId;
                var success = await _userService.DeleteUserByIdAsync(userId);
                _logger.LogInformation($"{success}");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}