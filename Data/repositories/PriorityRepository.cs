using Data.context;
using Domain.models;
using Microsoft.EntityFrameworkCore;

namespace Data.repositories
{
    public class PriorityRepository : IPriorityRepository
    {
        private readonly HelpDeskDbContext _context;

        public PriorityRepository(HelpDeskDbContext context) => _context = context;

        public async Task<List<Priority>> GetPriorities()
        {
            var priorities = new List<Priority>();
            if (_context != null)
            {
                priorities = await _context.Priorities.ToListAsync();
            }
            return priorities;
        }

        public async Task<Priority> GetPriorityById(int priorityId)
        {
            var category = await _context.Priorities.FindAsync(priorityId) ?? new Priority();
            return category;
        }

        public bool PriorityExists(int priorityId)
        {
            if (_context != null)
            {
                return _context.Priorities.Any(e => e.PriorityId == priorityId);
            }
            return false;
        }

        public async Task UpdatePriority(Priority priority)
        {
            if (_context != null)
            {
                _context.Priorities.Update(priority).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Priority> AddPriority(Priority priority)
        {
            if (_context != null)
            {
                _context.Priorities.Add(priority);
                await _context.SaveChangesAsync();
            }
            return priority;
        }

        public async Task RemovePriority(Priority priority)
        {
            if (_context != null)
            {
                _context.Priorities.Remove(priority);
                await _context.SaveChangesAsync();
            }
        }
    }
}
