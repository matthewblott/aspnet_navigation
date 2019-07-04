using Microsoft.AspNetCore.Mvc;

namespace aspnet_template.controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult About()
    {
      return View();
    }
    
  }
    
}
