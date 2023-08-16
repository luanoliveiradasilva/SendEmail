using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using SendMail.Models;
using SendMail.Services;

namespace SendMail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailSendController : ControllerBase
    {
         private readonly IEmailServices _emailServices;

        public MailSendController(IEmailServices emailServices)
        {
            _emailServices = emailServices;
        }

        [HttpPost]
        public IActionResult SendMailSimple(EmailDto emailDto)
        {
            _emailServices.SendEmail(emailDto);

            return Ok();
        }

    }
}
