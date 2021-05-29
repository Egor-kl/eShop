using EventBus.Enums;

namespace EventBus.Events
{
    public interface ISendEmail
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public EmailType EmailType { get; set; }
    }
}