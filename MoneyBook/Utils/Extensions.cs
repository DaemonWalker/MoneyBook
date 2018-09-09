using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.Utils
{
    public static class Extensions
    {
        public static void AddAppSettings(this IServiceCollection services, IConfiguration config)
        {
            services.Add(new ServiceDescriptor(typeof(AppSettings), typeof(AppSettings), ServiceLifetime.Singleton));
            //读取配置文件
            AppSettings.ConnectionString = config["DataSource:ConnectionString"];
            AppSettings.DataBase = config["DataSource:DataBase"];

        }
    }
}
