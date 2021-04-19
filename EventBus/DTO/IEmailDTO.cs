using EventBus.Enums;

namespace EventBus.DTO
{
    public interface IEmailDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public EmailType EmailType { get; set; }
    }
}