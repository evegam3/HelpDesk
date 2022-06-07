using Domain.models;

namespace Data.repositories
{
    public interface IRolRepository
    {
        public Task<List<Rol>> GetRoles();
        bool RolExists(string rolId);
        public Task<Rol> GetRolById(string rolId);
        public Task UpdateRol(Rol rol);
        public Task<Rol> AddRol(Rol rol);
        public Task RemoveRol(Rol rol);
    }
}
