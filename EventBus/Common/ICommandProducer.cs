using System.Threading.Tasks;

namespace EventBus.Common
{
    /// <summary>
    ///     Define interface for commands producer.
    ///     Q -- ICommand interface,
    ///     T -- data transfer object.
    /// </summary>
    public interface ICommandProducer<Q, T>
    {
        /// <summary>
        ///     Send command to event bus.
        /// </summary>
        /// <param name="data">Data object to send.</param>
        Task<bool> Send(T data);
    }
}