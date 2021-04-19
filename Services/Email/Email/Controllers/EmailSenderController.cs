using System;
using System.Threading.Tasks;
using Email.Common.Interfaces;
using Email.DTO;
using EventBus.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Email.Controllers
{
    [ApiController]
    public class EmailSenderController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        private readonly IRazorViewToString _razorViewToString;

        public EmailSenderController(IRazorViewToString razorViewToString, IEmailSender emailSender)
        {
            _razorViewToString = razorViewToString ?? throw new ArgumentNullException(nameof(razorViewToString));
            _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
        }
        
        [HttpPost("SendEmail")]
        public async Task<IActionResult> SendEmail(EmailDTO emailDTO)
        {
            var body = await _razorViewToString.RenderViewToStringAsync("Views/Register.cshtml", emailDTO);

            var subject = emailDTO.EmailType switch
            {
                EmailType.Register => "Register on eShop!",
                _ => throw new ArgumentOutOfRangeException()
            };

            await _emailSender.SendEmailAsync(emailDTO.Email, subject, body);

            return Ok($"{emailDTO.Email} - {emailDTO.EmailType}");
        }
    }
}