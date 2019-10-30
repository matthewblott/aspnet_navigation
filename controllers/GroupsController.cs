using System.Collections.Generic;
using aspnet_template.services;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;

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

    [Breadcrumb("User", FromController = typeof(UsersController), FromAction = nameof(UsersController.List))]
    public IActionResult ListByUser(int userId)
    {
      var model = _userService.GetGroupsByUser(userId);

      return View("List", model);
      
    }
    
  }
  
}