namespace BethanysPieShop.Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int? PieId { get; set; }

        public TicketStatus TicketStatus { get; set; }
        public TicketType TicketType { get; set; }
        public List<TicketMessage> TicketMessages { get; set; }
        public int? CustomerSentimentScore { get; set; }

    }
}
