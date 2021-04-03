using System.Windows.Input;
using EventBus.DTO;

namespace EventBus.Commands
{
    public interface IRegisterProfile : ICommand
    {
        /// <summary>
        /// Data processing for create profile.
        /// </summary>
        IUserDTO User { get; set; }
    }
}