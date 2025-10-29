namespace BethanysPieShop.Model
{
    public class OrderDetail
    {
        
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public Pie Pie { get; set; }
        public int PieId { get; set; }
        public int Amount { get; set; }
    }
}