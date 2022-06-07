using Data.context;
using Domain.models;
using Microsoft.EntityFrameworkCore;
namespace Data.repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly HelpDeskDbContext _context;

        public RolRepository(HelpDeskDbContext context) => _context = context;

        public async Task<List<Rol>> GetRoles()
        {
            var roles = new List<Rol>();
            if (_context != null)
            {
                roles = await _context.Roles.ToListAsync();
            }
            return roles;
        }

        public bool RolExists(string rolId)
        {
            if (_context != null)
            {
                return _context.Roles.Any(e => e.Id == rolId);
            }
            return false;
        }

        public async Task<Rol> GetRolById(string rolId)
        {
            var rol = new Rol();
            if (_context != null)
            {
                rol = await _context.Roles.FirstOrDefaultAsync(x => x.Id == rolId) ?? new Rol();
            }
            return rol;
        }

        public async Task UpdateRol(Rol rol)
        {
            if (_context != null)
            {
                _context.Roles.Update(rol).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Rol> AddRol(Rol rol)
        {
            if (_context != null)
            {
                _context.Roles.Add(rol);
                await _context.SaveChangesAsync();
            }
            return rol;
        }

        public async Task RemoveRol(Rol rol)
        {
            if (_context != null)
            {
                _context.Roles.Remove(rol);
                await _context.SaveChangesAsync();
            }
        }

    }
}
