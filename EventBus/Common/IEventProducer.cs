using System.Threading.Tasks;

namespace EventBus.Common
{
    /// <summary>
    /// Interface for event producer.
    /// </summary>
    /// <typeparam name="Q">IEvent</typeparam>
    /// <typeparam name="T">DTO</typeparam>
    public interface IEventProducer<Q, T>
    {
        /// <summary>
        /// Sender event.
        /// </summary>
        /// <param name="someData"></param>
        /// <returns></returns>
        Task<bool> Publish(T someData);
    }
}