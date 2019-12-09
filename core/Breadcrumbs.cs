using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using aspnet_navigation.services;
using cloudscribe.Web.Navigation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace aspnet_navigation.core
{
  public class Breadcrumbs : IActionFilter
  {
    private readonly IOrderService _orderService;
    private readonly NavigationTreeBuilderService _builderService;
    private readonly IUrlHelperFactory _factory;

    public Breadcrumbs(IOrderService orderService, IServiceProvider services, NavigationTreeBuilderService builderService)
    {
      _orderService = orderService;
      _builderService = builderService;
      _factory = services.GetRequiredService<IUrlHelperFactory>();
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
      if (!(context.Controller is Controller))
      {
        return;
      }

      var currentNode = GetCurrentNode(context);
      var nodes = new List<NavigationNode>();

      while (currentNode != null)
      {
        nodes.Add(currentNode.Value);
        currentNode = currentNode.Parent;
      }

      var q = 
        from x in nodes 
        where x.Action != "Index" && !x.Action.StartsWith("List") && x.Action != "New"
        select x;

      var helper = _factory.GetUrlHelper(context);
      var keys = GetKeys(context.ActionArguments);

      foreach (var node in q)
      {
        var parameters = node.PreservedRouteParameters.Split(',', StringSplitOptions.RemoveEmptyEntries);
        
        var q0 =
          from x in parameters 
          where keys.Select(y => y.Key).Contains(x)
          select x;
        
        var values = new StringBuilder("?");

        foreach (var p in q0)
        {
          values.Append($"{p}={keys.Single(x => x.Key == p).Value}&");
        }

        var url = helper.Action(node.Action,  node.Controller, new { }) + values;
        var text = keys.Single(x => x.Key == parameters.Last()).Value;

        context.HttpContext.AdjustBreadcrumb(node.Key, text, url);

      }

    }

    private TreeNode<NavigationNode> GetCurrentNode(ActionExecutingContext context)
    {
      var result = _builderService.GetTree();
      var tree = result.Result;
      var controller = context.Controller as ControllerBase;
      var controllerName = controller?.ControllerContext.ActionDescriptor.ControllerName;
      var actionName = controller?.ControllerContext.ActionDescriptor.ActionName;
      var node = tree.FindByKey($"{controllerName}.{actionName}");

      return node;
      
    }
    
    private Dictionary<string, string> GetKeys(IDictionary<string, object> args)
    {
      var orderId = args.GetValueFromKey<int>("orderId");
      var userId = args.GetValueFromKey<int>("userId");
      var itemId = args.GetValueFromKey<int>("itemId");
      var sku = GetProductSku(orderId, itemId);

      var keys = new Dictionary<string, string>
      {
        {nameof(orderId), orderId.ToString()},
        {nameof(userId), userId.ToString()},
        {nameof(itemId), itemId.ToString()},
        {nameof(sku), sku}
      };

      return keys;
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