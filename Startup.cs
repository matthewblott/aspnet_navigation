using aspnet_template.services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartBreadcrumbs.Extensions;

namespace aspnet_template
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
//      services.AddCloudscribeNavigation(Configuration.GetSection("NavigationOptions"));
      
      services.AddScoped<IUserService, UserService>();
      services.AddMvc()
        .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

      services.AddBreadcrumbs(GetType().Assembly, options =>
      {
        options.TagName = "nav";
        options.TagClasses = "breadcrumb";
        options.OlClasses = string.Empty;
        options.LiClasses = string.Empty;
        options.ActiveLiClasses = "is-active";
        options.SeparatorElement = string.Empty;
      });
      
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseDeveloperExceptionPage();
      app.UseStaticFiles();
      app.UseMvcWithDefaultRoute();

    }
    
  }
  
}
