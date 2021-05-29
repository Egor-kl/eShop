using System;

namespace EventBus.Common
{
    /// <summary>
    ///     Message broker events.
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        ///     Event Id.
        /// </summary>
        public Guid EventId { get; set; }
    }
}