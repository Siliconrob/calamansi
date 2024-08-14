[assembly: HostingStartup(typeof(calamansi.ConfigureOpenApi))]

namespace calamansi;

public class ConfigureOpenApi : IHostingStartup
{
    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices((context, services) => {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddServiceStackSwagger();
            //services.AddBasicAuth<Data.ApplicationUser>();
            //services.AddJwtAuth();
            services.AddTransient<IStartupFilter,StartupFilter>();
        });

    public class StartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next) => app =>
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            next(app);
        };
    }
}
