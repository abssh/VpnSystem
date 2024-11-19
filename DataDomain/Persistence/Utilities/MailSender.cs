using DataDomain.Types.ConfigTypes;
using System.Net;
using System.Net.Mail;


namespace DataDomain.Persistence.Utilities
{
    public class MailSender
    {
        private SMTPConfig smtp;

        public MailSender(SMTPConfig smtp)
        {
            this.smtp = smtp;
        }

        public void SendEmail(string recipient, string subject, string body)
        {

            int port;
            int.TryParse(smtp.Port, out port);

            using var mailCli = new SmtpClient(smtp.Host, port);

            mailCli.UseDefaultCredentials = false;
            mailCli.Credentials = new NetworkCredential(smtp.Username, smtp.Password);
            mailCli.EnableSsl = true;

            using (var message = new MailMessage())
            {
                message.From = new MailAddress(smtp.Username);
                message.To.Add(recipient);
                message.CC.Add(smtp.Username);
                message.Body = body;
                message.Subject = subject;

                mailCli.Send(message);
            }
            Console.WriteLine("[my log] email was sent");
            
        }
    }
}
