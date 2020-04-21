namespace HotBag.AspNetCore.AppSettings.Application
{
    public class ApplicationSetting : IApplicationSetting
    {

        public string ApplicationName { get; private set; }
        public string ApplicationVersion { get; private set; }
        public bool SentDetailExceptionMessage { get; set; } = true;

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
}
