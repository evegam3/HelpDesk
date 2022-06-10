using Data.context;
using Domain.models;
using Microsoft.EntityFrameworkCore;

namespace Data.repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly HelpDeskDbContext _context;

        public StatusRepository(HelpDeskDbContext context) => _context = context;

        public async Task<List<Status>> GetStatuses()
        {
            var statuses = new List<Status>();
            if (_context != null)
            {
                statuses = await _context.Statuses.ToListAsync();
            }
            return statuses;
        }
    }
}
