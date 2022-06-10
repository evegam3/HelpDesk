using AutoMapper;
using Data.repositories;
using Domain.models.dto;

namespace Data.services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _autoMapper;

        public StatusService(IStatusRepository statusRepository, IMapper autoMapper)
        {
            _statusRepository = statusRepository;
            _autoMapper = autoMapper;
        }

        public async Task<List<StatusDto>> GetStatuses()
        {
            return _autoMapper.Map<List<StatusDto>>(await _statusRepository.GetStatuses());
        }

    }
}
