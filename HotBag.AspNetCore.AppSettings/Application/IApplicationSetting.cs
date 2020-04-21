namespace HotBag.AspNetCore.AppSettings.Application
{
    public interface IApplicationSetting
    {
        string ApplicationName { get; }
        bool SentDetailExceptionMessage { get; set; }
        string ApplicationVersion { get; }
        void SetApplicationSetting(string name);
    }
}
