using aspnet_template.services;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_template.controllers
{
  public class GroupsController : Controller
  {
    private readonly IUserService _userService;

    public GroupsController(IUserService userService) => _userService = userService;
    
    public IActionResult Index() => View();

    public IActionResult ListByUser(int userId) => View("List", _userService.GetGroupsByUser(userId));
  }
  
}