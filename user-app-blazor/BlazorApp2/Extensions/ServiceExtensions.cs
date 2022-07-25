using BlazorApp2.HttpRepository;

namespace BlazorApp2.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureHttpClient(this IServiceCollection services)
        {
            services.AddScoped(sp =>
             new HttpClient
             {
                 BaseAddress = new Uri("https://localhost:7198/api/"),
             });

            services.AddScoped<IUserHttpRepository, UserHttpRepository>();
         
        }

   

    }
}
