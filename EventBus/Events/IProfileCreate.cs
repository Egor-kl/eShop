using EventBus.Common;

namespace EventBus.Events
{
    public interface IProfileCreate : IEvent
    {
        /// <summary>
        /// User id. Identity
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Profile id
        /// </summary>
        public int ProfileId { get; set; }
    }
}