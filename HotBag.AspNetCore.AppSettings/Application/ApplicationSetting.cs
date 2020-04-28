namespace HotBag.AspNetCore.AppSettings.Application
{
    public class ApplicationSetting : IApplicationSetting
    {

        public string ApplicationName { get; private set; }
        public string ApplicationVersion { get; private set; }
        public bool SentDetailExceptionMessage { get; set; } = true;

        public ApplicationFeatures Features { get; set; } = new ApplicationFeatures();

        public ApplicationSetting()
        {
            this.ApplicationName = "HotBag Enterprise Boilerplate Framework";
            this.ApplicationVersion = "3.0.0.0 - final";
        }

        public void SetApplicationSetting(string name)
        {
            this.ApplicationName = name;
        }
    }

    public class ApplicationFeatures
    {
        public bool IsEnableSwaggerApiDoc { get; set; } = true;
        public bool IsEnableResultWrapper { get; set; } = true;
        public bool IsEnableEventBus { get; set; } = true;
        public bool IsEnableAutoMapper { get; set; } = true;
        public bool IsEnableLog { get; set; } = true;
        public bool IsEnableCORS { get; set; } = true;
        public bool IsEnableSignalR { get; set; } = true;
    }


}
