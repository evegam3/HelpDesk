using Domain.models.dto;

namespace Data.services
{
    public interface IRolService
    {
        public Task<List<RolDto>> GetRoles();
        public Task<RolDto> GetRolById(string rolId);
        bool RolExists(string rolId);
        public Task UpdateRol(RolDto rolDto);
        public Task RemoveRol(RolDto rol);
        public Task AddRol(RolDto rolDto);
    }
}
