using Data.context;
using Domain.models;
using Microsoft.EntityFrameworkCore;

namespace Data.repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly HelpDeskDbContext _context;

        public UserRoleRepository(HelpDeskDbContext context) => _context = context;

        public async Task<List<UserRole>> GetUserRoles()
        {
            var UserRoles = new List<UserRole>();
            if (_context != null)
            {
                UserRoles = await _context.UserRoles.ToListAsync();
            }
            return UserRoles;
        }

        public bool RolesUsersExists(string rolId, string userId)
        {
            if (_context != null)
            {
                return _context.UserRoles.Any(e => e.RoleId == rolId && e.UserId == userId);
            }
            return false;
        }

        public async Task<UserRole> GetRolesUsersByIds(string rolId, string userId)
        {
            var rol = new UserRole();
            if (_context != null)
            {
                rol = await _context.UserRoles
                    .Include(u => u.Role)
                    .Include(u => u.User)
                    .FirstOrDefaultAsync(e => e.RoleId == rolId && e.UserId == userId)
                    ?? new UserRole();
            }
            return rol;
        }

        public async Task UpdateRolesUsers(UserRole userRole)
        {
            if (_context != null)
            {
                _context.UserRoles.Update(userRole).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<UserRole> AddRolesUsers(UserRole userRole)
        {
            if (_context != null)
            {
                _context.UserRoles.Add(userRole);
                await _context.SaveChangesAsync();
            }
            return userRole;
        }

        public async Task RemoveRolesUsers(UserRole userRole)
        {
            if (_context != null)
            {
                _context.UserRoles.Remove(userRole);
                await _context.SaveChangesAsync();
            }
        }
    }
}
