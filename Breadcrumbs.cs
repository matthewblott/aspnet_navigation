using System;
using System.Collections.Generic;
using System.Linq;
using aspnet_template.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace aspnet_template
{
  public class Breadcrumbs : IActionFilter
  {
    private readonly IOrderService _orderService;

    public Breadcrumbs(IOrderService orderService)
    {
      _orderService = orderService;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
      if (!(context.Controller is Controller))
      {
        return;
      }

      var args = context.ActionArguments;
      var orderId = args.GetValueFromKey<int>("orderId");
      var userId = args.GetValueFromKey<int>("userId");
      var itemId = args.GetValueFromKey<int>("itemId");
      var sku = GetProductSku(orderId, itemId);
      
      context.HttpContext.AdjustBreadcrumb("User", $"User # {userId}");
      context.HttpContext.AdjustBreadcrumb("Order", $"Order # {orderId}");
      context.HttpContext.AdjustBreadcrumb("OrderItems", $"Order # {orderId} items");
      context.HttpContext.AdjustBreadcrumb("OrderItem", $"Order Item # {itemId}");
      context.HttpContext.AdjustBreadcrumb("Product", $"{sku}");

    }

    private string GetProductSku(int orderId, int itemId)
    {
      if (orderId == default || itemId == default)
      {
        return string.Empty;
      }
      
      var order = _orderService.GetById(orderId);
      var items = order.Items;

      var q =
        from x in items 
        where x.ItemId == itemId 
        select x;

      var item = q.Single();
      var product = item.Product;

      return product.Sku;

    }
    
    public void OnActionExecuted(ActionExecutedContext context)
    {
      
    }
    
  }
  
}