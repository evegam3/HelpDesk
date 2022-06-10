using Domain.models.dto;

namespace Data.services
{
    public interface IStatusService
    {
        public Task<List<StatusDto>> GetStatuses();
    }
}
