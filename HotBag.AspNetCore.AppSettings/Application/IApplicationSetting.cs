namespace HotBag.AspNetCore.AppSettings.Application
{
    public interface IApplicationSetting
    {
        string ApplicationName { get; }
        bool SentDetailExceptionMessage { get; set; }
        string ApplicationVersion { get; } 

        ApplicationFeatures Features { get; set; } 
        void SetApplicationSetting(string name);
    }
}
