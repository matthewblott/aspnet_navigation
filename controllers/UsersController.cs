using aspnet_navigation.models;
using aspnet_navigation.services;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_navigation.controllers
{
  public class UsersController : Controller
  {
    private readonly IUserService _userService;
    public UsersController(IUserService userService) => _userService = userService;

    public IActionResult Index() => View(new User());

    public IActionResult List() => View(_userService.GetAll());

    public IActionResult Edit(int userId)
    {
      if (userId == default)
      {
        return RedirectToAction(nameof(List));
      }
      
      return View(_userService.GetById(userId));
      
    }

    [HttpPost]
    public IActionResult Create() => RedirectToAction(nameof(Index));

    [HttpPost]
    public IActionResult Update() => RedirectToAction(nameof(Index));
    
  }
  
}