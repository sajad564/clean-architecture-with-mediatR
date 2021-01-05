using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace book.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var appSettingDirectory = $"{Directory.GetCurrentDirectory()}\\appsettings.json" ; 
            var config = new ConfigurationBuilder().AddJsonFile(appSettingDirectory).Build() ; 
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger() ; 
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseSerilog() 
            .UseStartup<Startup>();
    }
}
