using Microsoft.AspNetCore.Mvc;
using aspnet_template.models;
using aspnet_template.services;
using SmartBreadcrumbs.Attributes;
using SmartBreadcrumbs.Nodes;

namespace aspnet_template.controllers
{
  public class UsersController : Controller
  {
    private readonly IUserService _userService;
    public UsersController(IUserService userService) => _userService = userService;
    
    [Breadcrumb]
    public IActionResult Index()
    {
      var userViewModel = new User();
      
      return View(userViewModel);
    }

    [Breadcrumb("Users")]
    public IActionResult List()
    {
      var model = _userService.GetAll();
      
      return View(model);
      
    }
    
    [Breadcrumb("User", FromAction = nameof(List))]
    public IActionResult Edit(int userId)
    {
      var model = _userService.GetById(userId);
     
      // Manually create the nodes (assuming you used the attribute to create a Default node, otherwise create it manually too).
      //var categoryNode = new BreadcrumbNode(product.Category.Name, "Controller", "Category", null, new { id = 10 });
      // When manually creating nodes, you have the option to use route values in case you need them.
      //var productNode = new BreadcrumbNode(product.Title, "Controller", "Product", categoryNode);
 
      // All you have to do now is tell SmartBreadcrumbs about this
      //ViewData["BreadcrumbNode"] = productNode; // Use the last node
      
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