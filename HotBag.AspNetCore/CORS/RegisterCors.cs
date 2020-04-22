
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace HotBag.AspNetCore.CORS
{
    public static class RegisterCors
    {
        public static IServiceCollection RegisterHotBagCORS(this IServiceCollection services, IConfiguration configuration, string defaultCorsPolicyName)
        {
            // Configure CORS for angular2 UI
            var cors = configuration["App:CorsOrigins"]
                               .Split(new string[1] { "," }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(o => Regex.Replace(o, @"/", ""))
                               .ToArray();

            services.AddCors(
                options => options.AddPolicy(
                    defaultCorsPolicyName,
                    builder => builder
                        .WithOrigins(cors)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                )
            );

            return services;
        }
    }

}
