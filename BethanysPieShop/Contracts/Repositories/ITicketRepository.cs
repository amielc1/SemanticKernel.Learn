using BethanysPieShop.Model;

namespace BethanysPieShop.Contracts.Repositories
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllTickets();
        Task<Ticket> GetTicketById(int ticketId);
        Task<Ticket> AddTicket(Ticket ticket);
        Task<Ticket> UpdateTicket(Ticket ticket);
        Task<Ticket> AddMessageToTicket(Ticket ticket, TicketMessage ticketMessage);
        Task DeleteTicket(int ticketId);
        Task<IEnumerable<Ticket>> GetTicketByCustomerId(string customerId);
        Task<IEnumerable<Ticket>> GetTicketsByStatus(TicketStatus ticketStatus);
    }
}
