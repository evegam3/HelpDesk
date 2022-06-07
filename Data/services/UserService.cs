using AutoMapper;
using Data.repositories;
using Domain.models;
using Domain.models.dto;

namespace Data.services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _autoMapper;

        public UserService(IUserRepository userRepository, IMapper autoMapper)
        {
            _userRepository = userRepository;
            _autoMapper = autoMapper;
        }

        public async Task<List<UserDto>> GetUsers()
        {
            return _autoMapper.Map<List<UserDto>>(await _userRepository.GetUsers());
        }

        public async Task<UserDto> GetUserById(string userId)
        {
            return _autoMapper.Map<UserDto>(await _userRepository.GetUserById(userId));
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            var user = await _userRepository.GetUserById(userDto.Id);

            if (user != null)
            {
                _autoMapper.Map(userDto, user);
                await _userRepository.UpdateUser(user);
            }
        }
    }
}
