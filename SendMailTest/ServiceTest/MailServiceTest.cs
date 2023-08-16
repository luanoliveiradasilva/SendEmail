using MailKit.Net.Smtp;
using MimeKit;
using Moq;
using SendMail.Models;
using SendMail.Services;
using System.Net.Mail;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace SendMailTest.ServiceTest
{
    [TestFixture]
    public class MailServiceTest
    {
        private MailService _mailService;
        private Mock<IConfiguration> _configuration;
        private Mock<SmtpClient> _smtpClient;

        [SetUp]
        public void SetUp()
        {
            _configuration = new Mock<IConfiguration>();
            _smtpClient = new Mock<SmtpClient>();
            _mailService = new MailService(_configuration.Object, _smtpClient.Object);
        }

        [Test]
        public void ShouldSendEmail()
        {
            //Given
            var emailUsername = "teste@ethereal.email";
            var emailPassword = "12BNn6GqhdrQBSqYf3";
            var EmailHost = "smtp.ethereal.email";

            var emailDto = new EmailDto();
            emailDto.Subject = "Teste";
            emailDto.From = "Teste";
            emailDto.Body = "Teste";
            emailDto.To = "Teste";

            //When
            _configuration.Setup(configuration => configuration.GetSection("Emailusername").Value).Returns(emailUsername);
            _configuration.Setup(configuration => configuration.GetSection("EmailHost").Value).Returns(emailPassword);
            _configuration.Setup(configuration => configuration.GetSection("EmailPassword").Value).Returns(EmailHost);


            //Then
            _mailService.SendEmail(emailDto);
        }

        [Test]
        public void ShouldReturnExceptionInSendEmail()
        {
            //Given
            var emailDto = new EmailDto();
            emailDto.Subject = "Teste";
            emailDto.From = "Teste";
            emailDto.Body = "Teste";
            emailDto.To = "Teste";

            //When
            var result = Assert.Throws<ArgumentException>(() => _mailService.SendEmail(emailDto));

            Assert.AreEqual("Failed to send the email.", result.Message);
            
        }
    }
}
