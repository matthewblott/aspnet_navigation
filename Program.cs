using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace aspnet_template
{
  public class Program
  {
    public static void Main(string[] args)
    {
      BuildWebHost(args).Build().Run();
    }

    private static IWebHostBuilder BuildWebHost(string[] args) =>
      WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>();
  }
  
}
