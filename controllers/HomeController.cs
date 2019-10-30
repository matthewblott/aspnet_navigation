using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;

namespace aspnet_template.controllers
{
  public class HomeController : Controller
  {
    [DefaultBreadcrumb("Home")]
    public IActionResult Index()
    {
      return View();
    }
    
    [Breadcrumb("About Us")]
    public IActionResult About()
    {
      return View();
    }
   
    [Breadcrumb("About Me")]
    public IActionResult AboutMe()
    {
      ViewData["Message"] = "about me page.";

      return View("About");
    }

    [Breadcrumb("Education", FromAction = nameof(AboutMe))]
    public IActionResult AboutMeEducation()
    {
      ViewData["Message"] = "about me education page.";

      return View("About");
    }

    [Breadcrumb("Employment", FromAction = nameof(AboutMe))]
    public IActionResult AboutMeEmployment()
    {
      ViewData["Message"] = "about me employment page.";

      return View("About");
    }
    
    public IActionResult AboutCompany()
    {
      ViewData["Message"] = "about company page.";

      return View("About");
    }

    public IActionResult AboutProject()
    {
      ViewData["Message"] = "about project page.";

      return View("About");
    }

    public IActionResult Contact()
    {
      return View();
    }
    
  }
    
}
