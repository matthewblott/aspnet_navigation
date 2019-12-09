using aspnet_navigation.services;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_navigation.controllers
{
  public class ProductsController : Controller
  {
    private readonly IProductService _productService;

    public ProductsController(IProductService orderService) => _productService = orderService;

    public IActionResult Show(string sku, int orderId, int itemId) => View(_productService.GetBySku(sku));
  }
  
}