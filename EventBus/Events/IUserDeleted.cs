using EventBus.Common;

namespace EventBus.Events
{
    /// <summary>
    ///     For user deleted
    /// </summary>
    public interface IUserDeleted : IEvent
    {
        /// <summary>
        ///     User Id for Identity.API
        /// </summary>
        public int UserId { get; set; }
    }
}