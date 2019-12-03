using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using aspnet_template.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using Humanizer;

namespace aspnet_template
{
  public class Breadcrumbs : IActionFilter
  {
    private readonly IOrderService _orderService;
    private readonly IActionDescriptorCollectionProvider _provider;
    private readonly IUrlHelperFactory _factory;

    public Breadcrumbs(IOrderService orderService, IActionDescriptorCollectionProvider provider,
      IServiceProvider services)
    {
      _orderService = orderService;
      _provider = provider;
      _factory = services.GetRequiredService<IUrlHelperFactory>();
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
      var items = _provider.ActionDescriptors.Items;
      var helper = _factory.GetUrlHelper(context);

      var keys = new Dictionary<string, string>
      {
        {nameof(orderId), orderId.ToString()},
        {nameof(userId), userId.ToString()},
        {nameof(itemId), itemId.ToString()},
        {nameof(sku), sku}
      };

      foreach (var item in items)
      {
        const string action = nameof(action);
        const string controller = nameof(controller);

        var act = item.RouteValues[action];
        var ctl = item.RouteValues[controller];
        var values = new StringBuilder("?");
        var key = $"{ctl}.{act}";

        foreach (var p in item.Parameters)
        {
          if (keys.Any(x => x.Key == p.Name))
          {
            var (s, value) = keys.Single(x => x.Key == p.Name);

            values.Append($"{s}={value}&");
              
          }
          
        }

        var url = helper.Action(act, ctl, new { }) + values;
        var text = act.Titleize();
        
        context.HttpContext.AdjustBreadcrumb(key.Titleize(), text, url);
          
      }
      
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

    public void OnActionExecuted(ActionExecutedContext context) { }
    
  }
  
}