using System.Collections.Generic;
using aspnet_template.models;

namespace aspnet_template.services
{
  public interface IProductService
  {
    IEnumerable<Product> GetAll();
    Product GetBySku(string sku);
  }
}