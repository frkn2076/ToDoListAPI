using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace Service.Notifier;

public static class MailSender
{
    public static void SendMail(string to, string from, string password, int taskCount)
    {
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse(from);
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = "Your Daily Report";

        var body = $"You completed {taskCount} tasks today";

        email.Body = new TextPart(TextFormat.Html) { Text = body };

        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        smtp.Authenticate(from, password);
        smtp.Send(email);
        smtp.Disconnect(true);
    }
}
