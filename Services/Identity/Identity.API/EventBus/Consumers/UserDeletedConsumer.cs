using System;
using System.Threading.Tasks;
using EventBus.DTO;
using EventBus.Events;
using Identity.Common.Interfaces;
using MassTransit;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace Identity.EventBus.Consumers
{
    public class UserDeletedConsumer : IConsumer<IUserDeleted>
    {
        private readonly IUserService _userService;
        private readonly Logger _logger;

        public UserDeletedConsumer(IUserService userService, Logger logger)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger;
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
                var userId = context.Message.UserId;
                var success = await _userService.DeleteUserByIdAsync(userId);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
        }
    }
}