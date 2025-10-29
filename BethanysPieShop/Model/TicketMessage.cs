namespace BethanysPieShop.Model
{
    public class TicketMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string? MessageEn { get; set; } = string.Empty;
        public bool IsSupportMessage { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Language { get; set; }
        public TicketMessageSentiment? TicketMessageSentiment { get; set; }
    }
}
