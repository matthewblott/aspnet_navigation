using System.Linq;
using aspnet_navigation.services;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_navigation.controllers
{
  public class OrderItemsController : Controller
  {
    private readonly IOrderService _orderService;

    public OrderItemsController(IOrderService orderService) => _orderService = orderService;

    public IActionResult Index() => View();

    public IActionResult List() => View();

    public IActionResult ListByOrder(int orderId) => View(nameof(List), _orderService.GetById(orderId).Items);

    public IActionResult Show(int orderId, int itemId)
    {
      var order = _orderService.GetById(orderId);
      var items = order.Items;
      var q = from x in items where x.ItemId == itemId select x;
      var item = q.Single();
      
      return View(item);
    }

  }
  
}