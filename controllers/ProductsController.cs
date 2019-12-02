using System.Linq;
using aspnet_template.services;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_template.controllers
{
  public class ProductsController : Controller
  {
    private readonly IOrderService _orderService;

    public ProductsController(IOrderService orderService) => _orderService = orderService;

    public IActionResult Show(int orderId, int itemId)
    {
      var order = _orderService.GetById(orderId);
      var items = order.Items;

      var q =
        from x in items 
        where x.ItemId == itemId 
        select x;

      var item = q.Single();
      var product = item.Product;
      
      return View(product);
      
    }
      
  }
  
}