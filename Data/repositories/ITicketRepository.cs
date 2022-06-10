using Domain.Enums;
using Domain.models;

namespace Data.repositories
{
    public interface ITicketRepository
    {
        public Task<List<Ticket>> GetTickets();
        public Task<List<Ticket>> GetTicketsByStatus(Statuses status);
        public bool TicketExists(int ticketId);
        public Task<Ticket> GetTicketById(int ticketId);
        public Task UpdateTicket(Ticket Ticket);
        public Task<Ticket> AddTicket(Ticket Ticket);
        public Task RemoveTicket(Ticket Ticket);
    }
}