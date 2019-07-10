using Microsoft.AspNetCore.Mvc;
using aspnet_template.models;
using aspnet_template.services;

namespace aspnet_template.controllers
{
  public class UsersController : Controller
  {
    private readonly IUserService _userService;
    public UsersController(IUserService userService) => _userService = userService;
    
    public IActionResult Index()
    {
      var userViewModel = new User();
      
      return View(userViewModel);
    }

    public IActionResult List()
    {
      var model = _userService.GetAll();
      
      return View(model);
      
    }
    
    public IActionResult Edit(int userId)
    {
      var model = _userService.GetById(userId);
      
      return View(model);
      
    }
    
    [HttpPost]
    public IActionResult Create()
    {
      return RedirectToAction(nameof(Index));

    }
    
    [HttpPost]
    public IActionResult Update()
    {
      return RedirectToAction(nameof(Index));
    }
    
  }
  
}