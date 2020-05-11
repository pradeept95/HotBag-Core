using MailKit.Security;

namespace HotBag.AspNetCore.MailKit
{
    public interface IHotBagMailKitConfiguration
    {
        SecureSocketOptions? SecureSocketOption { get; set; }
    }
}
