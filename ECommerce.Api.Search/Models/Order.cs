namespace ECommerce.Api.Search.Models
{
    public class Order
    {
        public Order()
        {
            Items = new List<OrderItem>();
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }

        public List<OrderItem> Items { get; set; }
    }
}
