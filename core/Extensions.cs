using System;
using System.Collections.Generic;
using System.Linq;

namespace aspnet_navigation.core
{
  public static class Extensions
  {
    public static string GetValueFromKey(this IDictionary<string, object> dictionary, string keyName) => 
      dictionary.FirstOrDefault(x => x.Key == keyName).Value?.ToString();

    public static T GetValueFromKey<T>(this IDictionary<string, object> dictionary, string keyName)
    {
      var value = GetValueFromKey(dictionary, keyName);

      if (typeof(T) == typeof(int) && !string.IsNullOrWhiteSpace(value))
      {
        return (T)Convert.ChangeType(value, typeof(T));
      }

      return default;

    }
    
  }
  
}