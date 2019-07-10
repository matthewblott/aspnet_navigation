using aspnet_template.services;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_template.controllers
{
  public class GroupsController : Controller
  {
    private readonly IUserService _userService;

    public GroupsController(IUserService userService) => _userService = userService;
    
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult ListByUser(int userId)
    {
      var model = _userService.GetGroupsByUser(userId);

      return View("List", model);
      
    }
    
  }
  
}