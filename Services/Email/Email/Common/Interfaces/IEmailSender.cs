using System.Threading.Tasks;
using Email.DTO;

namespace Email.Common.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailDTO emailDTO);
    }
}