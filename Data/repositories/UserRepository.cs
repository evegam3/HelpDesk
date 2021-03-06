using Data.context;
using Domain.models;
using Microsoft.EntityFrameworkCore;

namespace Data.repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HelpDeskDbContext _context;

        public UserRepository(HelpDeskDbContext context) => _context = context;

        public async Task<List<User>> GetUsers()
        {
            var users = new List<User>();
            if (_context != null)
            {
                users = await _context.Users.ToListAsync();
            }
            return users;
        }

        public async Task<User> GetUserById(string userId)
        {
            var user = new User();
            if (_context != null)
            {
                user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId) ?? new User();
            }
            return user;
        }

        public string GetUserName(string userId)
        {
            var user = new User();
            if (_context != null)
            {
                user = _context.Users.Find(userId) ?? new User();
            }
            return string.Concat(user.Name, " ", user.Lastname);
        }

        public async Task UpdateUser(User user)
        {
            if (_context != null)
            {
                _context.Users.Update(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
