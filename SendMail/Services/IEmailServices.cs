using SendMail.Models;

namespace SendMail.Services
{
    public interface IEmailServices
    {

        public void SendEmail(EmailDto mailDto);
    }
}
