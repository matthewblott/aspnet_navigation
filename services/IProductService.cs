using System.Collections.Generic;
using aspnet_navigation.models;

namespace aspnet_navigation.services
{
  public interface IProductService
  {
    IEnumerable<Product> GetAll();
    Product GetBySku(string sku);
  }
}