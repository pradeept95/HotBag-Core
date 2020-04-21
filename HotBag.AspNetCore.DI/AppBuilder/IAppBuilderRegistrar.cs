﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;

namespace HotBag.AspNetCore.DI
{
    public interface IAppBuilderRegistrar
    {
        void Configure(IApplicationBuilder app, IServiceProvider serviceProvider, IHostingEnvironment env);
    }
}
