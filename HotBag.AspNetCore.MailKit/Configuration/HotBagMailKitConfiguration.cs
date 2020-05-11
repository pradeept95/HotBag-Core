using MailKit.Security;

namespace HotBag.AspNetCore.MailKit
{
    public class HotBagMailKitConfiguration : IHotBagMailKitConfiguration
    {
        public SecureSocketOptions? SecureSocketOption { get; set; }
    }
}
