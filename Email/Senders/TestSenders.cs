using Email.Interfaces;
using Email.Options;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;

namespace Email.Senders
{
    public class TestSenders : IEmailSender
    {
        private readonly EmailOptions _options;

        public TestSenders(EmailOptions options)
        {
            _options = options;
        }

        public TestSenders(IOptions<EmailOptions> options)
        {
            _options = options.Value;
        }

        public string Body { get; set; }
        public string Subject { get; set; }
        public string EmailTo { get; set; }

        public void Send()
        {
            var fromAddress = new MailAddress(_options.FromEmail, _options.FromName);

            Console.WriteLine($"Sending an email to [{EmailTo}], subject: [{Subject}], body: [{Body}]");

            var smtp = new SmtpClient
            {
                Host = _options.Host,
                Port = _options.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, _options.FromPassword)
            };

            using (var message = new MailMessage("no-reply@email.com", EmailTo)
            {
                Subject = Subject,
                Body = Body
            })
            {
                Console.WriteLine($"Email sent.");
                smtp.Send(message);
            }
        }
    }
}
