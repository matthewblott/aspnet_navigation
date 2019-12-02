using System.Collections.Generic;
using aspnet_template.models;

namespace aspnet_template.services
{
  public interface IOrderService
  {
    Order GetById(int id);
    IEnumerable<Order> GetAll();
    IEnumerable<Order> GetByUser(int userId);
    
  }
  
}