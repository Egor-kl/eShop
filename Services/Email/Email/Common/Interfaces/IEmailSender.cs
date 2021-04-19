using System.Threading.Tasks;

namespace Email.Common.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}