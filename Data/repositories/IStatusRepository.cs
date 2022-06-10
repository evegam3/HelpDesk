using Domain.models;

namespace Data.repositories
{
    public interface IStatusRepository
    {
        public Task<List<Status>> GetStatuses();
    }
}
