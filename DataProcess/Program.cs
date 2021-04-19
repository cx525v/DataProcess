using DataProcess.Application;
using DataProcess.DataAccess;
using DataProcess.FiileMgnt;
using DataProcess.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DataProcess
{
    class Program
    {
        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<IStreamReader, FileStreamReader>();
            services.AddScoped<IFileMgr, FileMgr>();
            services.AddScoped<IDeviceDataHandler, DeviceDataHandler>();
            services.AddScoped<ITrackerDataHandler, TrackerDataHandler>();
            services.AddScoped(typeof(IJsonObjectReader<>), typeof(JsonObjectReader<>));
            services.AddScoped<IHandleData, HandleData>();
            services.AddTransient<MyApp>();
            return services;
        }

        static void Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetService<MyApp>().Run();
        }
    }
}
