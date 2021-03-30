using EventBus.Common;
using EventBus.DTO;

namespace EventBus.Events
{
    public interface IProfileCreate : IEvent
    {
        /// <summary>
        /// Profile DTO.
        /// </summary>
        public IProfileDTO ProfileDTO { get; set; }
    }
}