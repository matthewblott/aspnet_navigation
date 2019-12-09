using aspnet_navigation.services;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_navigation.controllers
{
  public class GroupsController : Controller
  {
    private readonly IUserService _userService;

    public GroupsController(IUserService userService) => _userService = userService;
    
    public IActionResult Index() => View();

    public IActionResult ListByUser(int userId) => View("List", _userService.GetGroupsByUser(userId));
  }
  
}