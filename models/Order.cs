using System.Collections.Generic;

namespace aspnet_navigation.models
{
  public class Order
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    
    public IEnumerable<OrderItem> Items { get; set; }
  }
  
}