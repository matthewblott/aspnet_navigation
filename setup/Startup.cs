using System.IO;
using aspnet_navigation.core;
using aspnet_navigation.services;
using cloudscribe.Web.Navigation;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace aspnet_navigation.setup
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true);

      builder.Build();
      
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
      services.AddScoped(x => x.GetRequiredService<IUrlHelperFactory>().
        GetUrlHelper(x.GetRequiredService<IActionContextAccessor>().ActionContext));
      services.AddCloudscribeNavigation(Configuration.GetSection("NavigationOptions"));
      services.AddScoped<INavigationTreeBuilder, JsonNavigationTreeBuilder>();
      services.AddScoped<IOrderService, OrderService>();
      services.AddScoped<IProductService, ProductService>();
      services.AddScoped<IUserService, UserService>();
      services.AddRouting(x => x.LowercaseUrls = true);
      services.AddMvc(x =>
        {
          x.EnableEndpointRouting = true;
          x.Filters.Add(typeof(Breadcrumbs));
        })
        .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
        .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
        .AddRazorRuntimeCompilation();
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseDeveloperExceptionPage();
      app.UseStaticFiles();
      app.UseRouting();
      app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());      
    }
    
    public static void Main(string[] args) =>
      WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build().Run();
    
  }
  
}
