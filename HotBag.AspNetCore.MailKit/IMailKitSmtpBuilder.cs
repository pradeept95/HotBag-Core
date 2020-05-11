using MailKit.Net.Smtp;

namespace HotBag.AspNetCore.MailKit
{
    public interface IMailKitSmtpBuilder
    {
        SmtpClient Build();
    }
}
