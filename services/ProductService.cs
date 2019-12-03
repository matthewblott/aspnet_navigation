using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using aspnet_template.models;
using Newtonsoft.Json;

namespace aspnet_template.services
{
  public class ProductService : IProductService
  {
    private const string Filename = "data/products.json";
    
    private readonly IList<Product> _products = new List<Product>();

    public ProductService()
    {
      if (!File.Exists(Filename)) return;

      var json = File.ReadAllText(Filename);

      _products = JsonConvert.DeserializeObject<IList<Product>>(json);
    }

    public IEnumerable<Product> GetAll() => _products;

    public Product GetBySku(string sku)
    {
      var q = from x in _products where x.Sku == sku select x;
      var product = q.FirstOrDefault();

      return product;
    }

  }
  
}