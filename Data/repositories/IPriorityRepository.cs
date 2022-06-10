using Domain.models;

namespace Data.repositories
{
    public interface IPriorityRepository
    {
        public Task<List<Priority>> GetPriorities();
        public Task<Priority> GetPriorityById(int priorityId);
        public bool PriorityExists(int priorityId);
        public Task UpdatePriority(Priority priority);
        public Task<Priority> AddPriority(Priority priority);
        public Task RemovePriority(Priority priority);
    }
}
