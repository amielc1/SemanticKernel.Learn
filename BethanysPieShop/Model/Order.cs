namespace BethanysPieShop.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<OrderDetail> OrderLines { get; set; }
        public int CustomerId{ get; set; }
        public DateTime OrderPlaced { get; set; }
    }
}
