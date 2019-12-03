using cloudscribe.Web.Navigation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace aspnet_template
{
  public static class ContextExtensions
  {
    public static void AdjustBreadcrumb(this HttpContext context, string key, string text) =>
      new NavigationNodeAdjuster(context)
      {
        KeyToAdjust = key, AdjustedText = text, ViewFilterName = "Breadcrumbs", AdjustedUrl = "",
      }.AddToContext();
   
    public static void AdjustBreadcrumb(this HttpContext context, string key, string text, string url) =>
      new NavigationNodeAdjuster(context)
      {
        KeyToAdjust = key, AdjustedText = text, ViewFilterName = "Breadcrumbs", AdjustedUrl = url,
      }.AddToContext();

    
  }
  
}