using BethanysPieShop.Contracts.Repositories;
using BethanysPieShop.Data;
using BethanysPieShop.Model;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TicketRepository(IDbContextFactory<ApplicationDbContext> DbFactory)
        {
            _applicationDbContext = DbFactory.CreateDbContext();
        }

        public async Task<Ticket> AddMessageToTicket(Ticket ticket, TicketMessage ticketMessage)
        {
            var foundTicket = await _applicationDbContext.Tickets.Include(t => t.TicketMessages).FirstOrDefaultAsync(e => e.Id == ticket.Id);

            //a new summary etc was created so this needs to be saved also
            foundTicket.Summary = ticket.Summary; 
            foundTicket.Title = ticket.Title;
            foundTicket.CustomerSentimentScore = ticket.CustomerSentimentScore;

            if (foundTicket != null)
            {
                foundTicket.TicketMessages.Add(ticketMessage);
                await _applicationDbContext.SaveChangesAsync();
                return foundTicket;
            }
            return null;
        }

        public async Task<Ticket> AddTicket(Ticket ticket)
        {
            var addedEntity = await _applicationDbContext.Tickets.AddAsync(ticket);
            await _applicationDbContext.SaveChangesAsync();
            return addedEntity.Entity;
        }

        public async Task DeleteTicket(int ticketId)
        {
            var foundTicket = await _applicationDbContext.Tickets.FirstOrDefaultAsync(e => e.Id == ticketId);
            if (foundTicket == null) return;

            _applicationDbContext.Tickets.Remove(foundTicket);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ticket>> GetAllTickets()
        {
            return await _applicationDbContext.Tickets.Include(t => t.TicketMessages).ToListAsync();
        }

        public async Task<Ticket> GetTicketById(int ticketId)
        {
            return await _applicationDbContext.Tickets.Include(t => t.TicketMessages).FirstOrDefaultAsync(c => c.Id == ticketId);
        }

        public async Task<IEnumerable<Ticket>> GetTicketByCustomerId(string customerId)
        {
            return await _applicationDbContext.Tickets.Where(c => c.CustomerId == customerId).ToListAsync();
        }

        public async Task<Ticket> UpdateTicket(Ticket ticket)//messages can't be updated!
        {
            var foundTicket = await _applicationDbContext.Tickets.FirstOrDefaultAsync(e => e.Id == ticket.Id);

            if (foundTicket != null)
            {
                foundTicket.TicketStatus = ticket.TicketStatus;
                foundTicket.TicketType = ticket.TicketType;
                foundTicket.PieId = ticket.PieId;
                foundTicket.Summary = ticket.Summary;

                await _applicationDbContext.SaveChangesAsync();

                return foundTicket;
            }

            return null;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByStatus(TicketStatus ticketStatus)
        {
            return await _applicationDbContext.Tickets.Where(c => c.TicketStatus == ticketStatus).OrderBy(t => t.CreatedDate).ToListAsync();
        }
    }
}
