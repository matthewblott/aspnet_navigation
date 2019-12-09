using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace aspnet_navigation.core
{
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
  public class BreadcrumbsAttribute : Attribute, IFilterFactory
  {
    public bool IsReusable => false;

    public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    {
      var service = serviceProvider.GetService<Breadcrumbs>();
      
      return service;
    }
    
  }

}