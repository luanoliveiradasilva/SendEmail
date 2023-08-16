using SendMail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMailTest.Models
{
    public class EmailDtoTest
    {

        private EmailDto _emailDtoTest;

        [SetUp]
        public void SetUp()
        {
            _emailDtoTest = new EmailDto();
        }

        [Test]
        public void EmailDatasDto()
        {

            //When 
            var subject = _emailDtoTest.Subject = "Subject";
            var body = _emailDtoTest.Body = "Body";
            var from = _emailDtoTest.From = "Teste@Teste";
            var to = _emailDtoTest.To = "Teste@Teste";

            //Then
            Assert.That("Subject", Is.EqualTo(subject));
            Assert.That("Body", Is.EqualTo(body));
            Assert.That("Teste@Teste", Is.EqualTo(from));
            Assert.That("Teste@Teste", Is.EqualTo(to));
        }
    }
}
