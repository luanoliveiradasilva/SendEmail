using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using SendMail.Models;
using MailKit.Net.Smtp;

namespace SendMail.Services
{
    public class MailService : IEmailServices
    {
        private readonly IConfiguration _configuration;
        private readonly SmtpClient _smtpClient;

        public MailService(IConfiguration configuration, SmtpClient smtpClient)
        {
            _configuration = configuration;
            _smtpClient = smtpClient;
        }

        //TODO remover o objeto e inserir uma injecao de dependencia.
        public void SendEmail(EmailDto mailDto)
        {
            try
            {
                var mail = new MimeMessage();
                mail.From.Add(MailboxAddress.Parse(_configuration.GetSection("Emailusername").Value));
                mail.To.Add(MailboxAddress.Parse(mailDto.To));
                mail.Subject = mailDto.Subject;
                mail.Body = new TextPart(TextFormat.Html) { Text = mailDto.Body };

                ConnectionSmtp(mail);

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Failed to send the email.");
            }

        }

        //TODO Remover essa funcao para uma classe de config
        public void ConnectionSmtp(MimeMessage mail)
        {
            try
            {
                _smtpClient.Connect(_configuration.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
                _smtpClient.Authenticate(_configuration.GetSection("Emailusername").Value, _configuration.GetSection("EmailPassword").Value);
                _smtpClient.Send(mail);
                _smtpClient.Disconnect(true);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Failed to connection with SMPT. ");
            }
        }
    }
}
