using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;
using Microsoft.Extensions.DependencyInjection;
using HotBag.AspNetCore.DI;
using HotBag.AspNetCore.EmailService.Service;

namespace HotBag.AspNetCore.EmailService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.File(@"C:\temp\HotBag\Microservices\EmailService\LogFile.txt")
                .CreateLogger();

            try
            {
                Log.Information("Starting up the application");
                CreateHostBuilder(args).Build().Run();
                return;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "There was a problem starting the serivce");
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    RegisterDependency.RegisterAll(services);
                    services.AddHostedService<EmailWorkerService>();
                    //services.AddSingleton<IEmaiService, EmailService>();
                })
                .UseSerilog();
        }
    }
}
