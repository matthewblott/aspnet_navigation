using Microsoft.AspNetCore.Mvc;
using aspnet_template.models;

namespace aspnet_template.controllers
{
  public class UsersController : Controller
  {
    public IActionResult Index()
    {
      var userViewModel = new UserViewModel();
      
      return View(userViewModel);
    }

    [HttpPost]
    public IActionResult Create()
    {
      return RedirectToAction(nameof(Index));

    }
    
  }
  
}