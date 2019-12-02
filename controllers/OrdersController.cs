using aspnet_template.services;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_template.controllers
{
  public class OrdersController : Controller
  {
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService) => _orderService = orderService;

    public IActionResult Index() => View();

    public IActionResult List() => View(_orderService.GetAll());

    public IActionResult Show(int orderId) => View( _orderService.GetById(orderId));

    [HttpPost]
    public IActionResult Create() => RedirectToAction(nameof(Index));

    [HttpPost]
    public IActionResult Update() => RedirectToAction(nameof(Index));
    
  }
  
}