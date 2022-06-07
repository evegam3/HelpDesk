using Domain.models;

namespace Data.repositories
{
    public interface IUserRoleRepository
    {
        public Task<List<UserRole>> GetUserRoles();
        public bool RolesUsersExists(string rolId, string userId);
        public Task<UserRole> GetRolesUsersByIds(string rolId, string userId);
        public Task UpdateRolesUsers(UserRole userRole);
        public Task<UserRole> AddRolesUsers(UserRole userRole);
        public Task RemoveRolesUsers(UserRole userRole);
    }
}
