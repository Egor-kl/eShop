using EventBus.DTO;
using EventBus.Enums;

namespace Email.DTO
{
    public class EmailDTO : IEmailDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public EmailType EmailType { get; set; }
    }
}