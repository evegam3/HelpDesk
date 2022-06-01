using Domain.models.dto;

namespace Data.services
{
    public interface IUserService
    {
        public Task<List<UserDto>> GetUsers();
        public Task<UserDto> GetUserById(string userId);
    }
}