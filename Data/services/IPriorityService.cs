using Domain.models.dto;

namespace Data.services
{
    public interface IPriorityService
    {
        public Task<List<PriorityDto>> GetPriorities();
        public Task<PriorityDto> GetPriorityById(int priorityId);
        public bool PriorityExists(int priorityId);
        public Task UpdatePriority(PriorityDto priorityDto);
        public Task AddPriority(PriorityDto priorityDto);
        public Task RemovePriority(PriorityDto priorityDto);
    }
}
