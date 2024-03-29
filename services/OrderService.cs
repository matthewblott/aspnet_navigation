using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using aspnet_navigation.models;
using Newtonsoft.Json;

namespace aspnet_navigation.services
{
  public class OrderService : IOrderService
  {
    private const string Filename = "data/orders.json";
    private readonly IList<Order> _orders = new List<Order>();

    public OrderService()
    {
      if (!File.Exists(Filename)) return;

      var json = File.ReadAllText(Filename);

      _orders = JsonConvert.DeserializeObject<IList<Order>>(json);
    }

    public IEnumerable<Order> GetAll() => _orders;

    public Order GetById(int id)
    {
      var q = from x in _orders where x.Id == id select x;
      var order = q.FirstOrDefault();

      return order;
    }

    public IEnumerable<Order> GetByUser(int userId)
    {
      var q = from x in _orders where x.Id == userId select x;
      
      var items = q.FirstOrDefault();

      throw new NotImplementedException();
      
    }
    
  }
  
}