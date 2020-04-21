using HotBag.AspNetCore.IO.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.AspNetCore.IO.Configuration
{ 
    public static class FileConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IFileService, FileService>();
        }
    }
}
