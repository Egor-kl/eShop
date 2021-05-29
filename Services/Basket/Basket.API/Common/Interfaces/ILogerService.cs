using Serilog.Core;

namespace Basket.API.Common.Interfaces
{
    public interface ILogerService
    {
        /// <summary>
        ///     Serilog configuration.
        /// </summary>
        /// <returns>Configuration.</returns>
        Logger SerilogConfiguration();
    }
}