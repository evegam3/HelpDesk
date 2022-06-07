
using Domain.models.dto;

namespace Data.services
{
    public interface IUserRoleService
    {
        public Task<List<UserRoleDto>> GetUserRoles();
        public bool RolesUsersExists(string rolId, string userId);
        public Task<UserRoleDto> GetRolesUsersByIds(string rolId, string userId);
        public Task UpdateRolesUsers(UserRoleDto userRoleDto);
        public Task AddRolesUsers(UserRoleDto userRoleDto);
        public Task RemoveRolesUsers(UserRoleDto userRoleDto);
    }
}
