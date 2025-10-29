using BethanysPieShop.Model;

namespace BethanysPieShop.Contracts.Services
{
    public interface ITicketDataService
    {
        Task<IEnumerable<Ticket>> GetAllTickets();
        Task<Ticket> GetTicketDetails(int TicketId);
        Task<Ticket> AddTicket(Ticket Ticket);
        Task UpdateTicket(Ticket Ticket);
        Task<Ticket> AddMessageToTicket(int ticketId, TicketMessage ticketMessage);
        Task DeleteTicket(int TicketId);
        Task<IEnumerable<Ticket>> GetTicketByCustomerId(string customerId);
        Task<IEnumerable<Ticket>> GetTicketsByStatus(TicketStatus ticketStatus);
    }
}
