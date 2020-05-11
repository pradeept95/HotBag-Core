namespace HotBag.AspNetCore.MailKit
{
    public static class HotBagMailKitConfigurationExtensions
    {
        public static IHotBagMailKitConfiguration HotBagMailKit(this HotBagMailKitConfiguration configurations)
        {
            return configurations;
            //return configurations.AbpConfiguration.Get<HotBagMailKitConfiguration>();
        }
    }
}
