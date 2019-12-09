using System.Collections.Generic;
using aspnet_navigation.models;

namespace aspnet_navigation.services
{
  public interface IOrderService
  {
    Order GetById(int id);
    IEnumerable<Order> GetAll();
    IEnumerable<Order> GetByUser(int userId);
    
  }
  
}