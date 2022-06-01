using Domain.models;

namespace Data.repositories
{
    public interface IUserRepository
    {
        public Task<List<User>> GetUsers();
        public Task<User> GetUserById(string userId);
    }
}