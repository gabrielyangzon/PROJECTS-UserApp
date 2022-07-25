using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user_logger;

namespace user_api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {


            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            
        }

        public static void ConfigureMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program));
        }


        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<IloggerManager, LoggerManager>();
        }
        
    }
}
