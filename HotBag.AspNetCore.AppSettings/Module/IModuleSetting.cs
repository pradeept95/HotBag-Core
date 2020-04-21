using System.Collections.Generic;

namespace HotBag.AspNetCore.AppSettings.Module
{
    public interface IModuleSetting
    {
        bool IsModuleInstalled(string moduleName);
        void RegisterModule(string moduleName);
        void InstallModule(string moduleName);
        ModuleInfo GetModuleInfo(string moduleName);
        List<ModuleInfo> GetAllModuleInfo();
        List<ModuleInfo> GetAllInstalledModuleInfo();
    }
}
