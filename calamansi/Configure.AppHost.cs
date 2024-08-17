[assembly: HostingStartup(typeof(calamansi.AppHost))]

namespace calamansi;

public class AppHost() : AppHostBase("calamansi"), IHostingStartup
{
    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices(services => {
            // Configure ASP.NET Core IOC Dependencies
        });

    public override void Configure()
    {
        // Configure ServiceStack, Run custom logic after ASP.NET Core Startup
        SetConfig(new HostConfig {
        });
        ConfigurePlugin<UiFeature>(feature => 
            feature.Info.BrandIcon = new ImageInfo { Uri = "/logo.svg", Cls = "w-8 h-8 mr-1" });
    }
}