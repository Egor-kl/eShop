using Serilog.Core;

namespace Identity.Common.Interfaces
{
    /// <summary>
    ///     Interface for serilog service.
    /// </summary>
    public interface ILogerService
    {
        /// <summary>
        ///     Serilog configuration.
        /// </summary>
        /// <returns>Configuration.</returns>
        Logger SerilogConfiguration();
    }
}