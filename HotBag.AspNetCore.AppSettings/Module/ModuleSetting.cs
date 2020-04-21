using System;
using System.Collections.Generic;
using System.Linq;

namespace HotBag.AspNetCore.AppSettings.Module
{
    public class ModuleSetting : IModuleSetting
    {
        IDictionary<string, bool> Modules = new Dictionary<string, bool>();

        public ModuleSetting()
        {
        }

        public void InstallModule(string moduleName)
        {
            if (string.IsNullOrEmpty(moduleName))
            {
                throw new NullReferenceException($"Module name can not be NULL or Empty");
            }
            if (!this.Modules.Any(x => x.Key == moduleName))
            {
                throw new InvalidOperationException($"Module with name : {moduleName} is not found to install");
            }
            this.Modules[moduleName] = true;
        }

        public void RegisterModule(string moduleName)
        {
            if (string.IsNullOrEmpty(moduleName))
            {
                throw new NullReferenceException($"Module name can not be NULL or Empty");
            }
            if (this.Modules.Any(x => x.Key == moduleName))
            {
                throw new InvalidOperationException($"Module with name : {moduleName} already exists in the system");
            }
            this.Modules.Add(moduleName, false);
        }

        public bool IsModuleInstalled(string moduleName)
        {
            if (string.IsNullOrEmpty(moduleName))
            {
                throw new NullReferenceException($"Module name can not be NULL or Empty");
            }
            return this.Modules.Any(x => x.Key == moduleName)
                ? this.Modules.First(x => x.Key == moduleName).Value
                : false;
        }

        public ModuleInfo GetModuleInfo(string moduleName)
        {
            if (string.IsNullOrEmpty(moduleName))
            {
                throw new NullReferenceException($"Module name can not be NULL or Empty");
            }

            return this.Modules.Any(x => x.Key == moduleName)
                 ? this.Modules.Select(x => new ModuleInfo { ModuleName = x.Key, IsInstalled = x.Value }).First()
                 : null;
        }

        public List<ModuleInfo> GetAllModuleInfo()
        {
            return this.Modules.Any()
                 ? this.Modules.Select(x => new ModuleInfo { ModuleName = x.Key, IsInstalled = x.Value }).ToList()
                 : null;
        }

        public List<ModuleInfo> GetAllInstalledModuleInfo()
        {
            return this.Modules.Any()
                 ? this.Modules.Select(x => new ModuleInfo { ModuleName = x.Key, IsInstalled = x.Value }).Where(x => x.IsInstalled).ToList()
                 : null;
        }
    }
}
