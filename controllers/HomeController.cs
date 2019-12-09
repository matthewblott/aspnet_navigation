using Microsoft.AspNetCore.Mvc;

namespace aspnet_navigation.controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index() => View();

    public IActionResult About() => View();

    public IActionResult AboutMe()
    {
      ViewData["Message"] = "about me page.";

      return View("About");
    }

    public IActionResult AboutMeEducation()
    {
      ViewData["Message"] = "about me education page.";

      return View("About");
    }

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

    public IActionResult Contact() => View();
    
  }
    
}
