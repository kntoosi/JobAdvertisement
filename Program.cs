using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Sinks.Syslog;
using System;

namespace CrouseServiceAdvertisement
{
    public class Program
    {
        [Obsolete]
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
           .SetBasePath(System.IO.Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();
            
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore", Serilog.Events.LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", Serilog.Events.LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.File(new CompactJsonFormatter(), "logs/log.log", rollingInterval: RollingInterval.Day)
                .WriteTo.TcpSyslog(
                    host: configuration.GetSection("LogServer:Host").Value,
                    port: configuration.GetSection("LogServer:Port").Value.ToInt(),
                    appName: configuration.GetSection("LogServer:AppName").Value,
                    format: SyslogFormat.RFC5424,
                    framingType: FramingType.CRLF,
                    secureProtocols: System.Security.Authentication.SslProtocols.None,
                    facility: Facility.Local0)
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("Starting Public Service web api host");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Public Service Web api host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
