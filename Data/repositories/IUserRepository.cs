using Domain.models;
using Domain.models.dto;

namespace Data.repositories
{
    public interface IUserRepository
    {
        public Task<List<User>> GetUsers();
        public Task<User> GetUserById(string userId);
        public Task UpdateUser(User user);
    }
}