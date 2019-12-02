using Microsoft.AspNetCore.Mvc;
using aspnet_template.models;
using aspnet_template.services;

namespace aspnet_template.controllers
{
  public class UsersController : Controller
  {
    private readonly IUserService _userService;
    public UsersController(IUserService userService) => _userService = userService;

    public IActionResult Index() => View(new User());

    public IActionResult List() => View(_userService.GetAll());

    public IActionResult Edit(int userId) => View(_userService.GetById(userId));

    [HttpPost]
    public IActionResult Create() => RedirectToAction(nameof(Index));

    [HttpPost]
    public IActionResult Update() => RedirectToAction(nameof(Index));
    
  }
  
}