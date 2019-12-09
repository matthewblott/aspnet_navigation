namespace aspnet_navigation.models
{
  public class OrderItem
  {
    public int OrderId { get; set; }
    public int ItemId { get; set; }

    public string Sku { get; set; }
    public int Quantity { get; set; }
    public Product Product { get; set; }
  }
}