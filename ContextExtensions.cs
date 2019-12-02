using cloudscribe.Web.Navigation;
using Microsoft.AspNetCore.Http;

namespace aspnet_template
{
  public static class ContextExtensions
  {
    public static void AdjustBreadcrumb(this HttpContext context, string key, string text) =>
      new NavigationNodeAdjuster(context)
      {
        KeyToAdjust = key, AdjustedText = text, ViewFilterName = "Breadcrumbs",
      }.AddToContext();
    
  }
  
}