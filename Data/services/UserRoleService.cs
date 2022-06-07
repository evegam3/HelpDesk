using AutoMapper;
using Data.repositories;
using Domain.models;
using Domain.models.dto;

namespace Data.services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _autoMapper;

        public UserRoleService(IUserRoleRepository userRoleRepository, IMapper autoMapper)
        {
            _userRoleRepository = userRoleRepository;
            _autoMapper = autoMapper;
        }

        public async Task<List<UserRoleDto>> GetUserRoles()
        {
            return _autoMapper.Map<List<UserRoleDto>>(await _userRoleRepository.GetUserRoles());
        }

        public async Task<UserRoleDto> GetRolesUsersByIds(string rolId, string userId)
        {
            return _autoMapper.Map<UserRoleDto>(await _userRoleRepository.GetRolesUsersByIds(rolId, userId));
        }

        public bool RolesUsersExists(string rolId, string userId)
        {
            return _userRoleRepository.RolesUsersExists(rolId, userId);
        }

        public async Task UpdateRolesUsers(UserRoleDto userRoleDto)
        {
            var userRole = await _userRoleRepository.GetRolesUsersByIds(userRoleDto.RoleId, userRoleDto.UserId);

            if (userRole != null)
            {
                _autoMapper.Map(userRoleDto, userRole);
                await _userRoleRepository.UpdateRolesUsers(userRole);
            }
        }

        public async Task AddRolesUsers(UserRoleDto userRoleDto)
        {
            if (userRoleDto != null)
            {
                var userRole = new UserRole()
                {
                    RoleId = userRoleDto.RoleId,
                    UserId = userRoleDto.UserId
                };
                await _userRoleRepository.AddRolesUsers(userRole);
            }
        }

        public async Task RemoveRolesUsers(UserRoleDto userRoleDto)
        {
            var userRole = await _userRoleRepository.GetRolesUsersByIds(userRoleDto.RoleId, userRoleDto.UserId);
            if (userRole != null)
            {
                _autoMapper.Map(userRoleDto, userRole);
                await _userRoleRepository.RemoveRolesUsers(_autoMapper.Map<UserRole>(userRole));
            }
        }
    }
}
