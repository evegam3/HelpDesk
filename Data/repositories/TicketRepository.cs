using Data.context;
using Domain.Enums;
using Domain.models;
using Microsoft.EntityFrameworkCore;

namespace Data.repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly HelpDeskDbContext _context;

        public TicketRepository(HelpDeskDbContext context) => _context = context;

        public async Task<List<Ticket>> GetTickets()
        {
            var Tickets = new List<Ticket>();
            if (_context != null)
            {
                Tickets = await _context.Tickets
                    .Include(x => x.Category)
                    .Include(x => x.Status)
                    .Include(x => x.Priority)
                    .ToListAsync();
            }
            return Tickets;
        }

        public async Task<List<Ticket>> GetTicketsByStatus(Statuses status)
        {
            var Tickets = new List<Ticket>();
            if (_context != null)
            {
               if(_context.Tickets.Any(x => x.StatusId == (int)status))
               {
                    Tickets = await _context.Tickets
                       .Include(x => x.Category)
                       .Include(x => x.Status)
                       .Include(x => x.Priority)
                       .Where(x => x.StatusId == (int)status).ToListAsync();
               }
            }
            return Tickets;
        }

        public bool TicketExists(int ticketId)
        {
            if (_context != null)
            {
                return _context.Tickets.Any(e => e.TicketId == ticketId);
            }
            return false;
        }

        public async Task<Ticket> GetTicketById(int ticketId)
        {
            var ticket = new Ticket();
            if (_context != null)
            {
                ticket = await _context.Tickets
                    .Include(u => u.Status)
                    .Include(u => u.Comments)
                    .Include(u => u.LogTimes)
                    .FirstOrDefaultAsync(e => e.TicketId == ticketId)
                    ?? new Ticket();
            }
            return ticket;
        }

        public async Task UpdateTicket(Ticket Ticket)
        {
            if (_context != null)
            {
                _context.Tickets.Update(Ticket).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Ticket> AddTicket(Ticket Ticket)
        {
            if (_context != null)
            {
                _context.Tickets.Add(Ticket);
                await _context.SaveChangesAsync();
            }
            return Ticket;
        }

        public async Task RemoveTicket(Ticket Ticket)
        {
            if (_context != null)
            {
                _context.Tickets.Remove(Ticket);
                await _context.SaveChangesAsync();
            }
        }
    }
}
