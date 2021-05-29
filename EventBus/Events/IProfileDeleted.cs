using EventBus.Common;

namespace EventBus.Events
{
    public interface IProfileDeleted : IEvent
    {
        /// <summary>
        ///     User Id
        /// </summary>
        public int UserId { get; set; }
    }
}