using AutoMapper;
using Data.repositories;
using Domain.models;
using Domain.models.dto;

namespace Data.services
{
    public class PriorityService : IPriorityService
    {
        private readonly IPriorityRepository _priorityRepository;
        private readonly IMapper _autoMapper;

        public PriorityService(IPriorityRepository priorityRepository, IMapper autoMapper)
        {
            _priorityRepository = priorityRepository;
            _autoMapper = autoMapper;
        }

        public async Task<List<PriorityDto>> GetPriorities()
        {
            return _autoMapper.Map<List<PriorityDto>>(await _priorityRepository.GetPriorities());
        }

        public async Task<PriorityDto> GetPriorityById(int priorityId)
        {
            return _autoMapper.Map<PriorityDto>(await _priorityRepository.GetPriorityById(priorityId));
        }

        public bool PriorityExists(int priorityId)
        {
            return _priorityRepository.PriorityExists(priorityId);
        }

        public async Task UpdatePriority(PriorityDto priorityDto)
        {
            var priority = await _priorityRepository.GetPriorityById(priorityDto.PriorityId);

            if (priority != null)
            {
                _autoMapper.Map(priorityDto, priority);
                await _priorityRepository.UpdatePriority(priority);
            }
        }

        public async Task AddPriority(PriorityDto priorityDto)
        {
            if (priorityDto != null)
            {
                var priority = new Priority()
                {
                    PriorityId = priorityDto.PriorityId,
                    Description = priorityDto.Description,
                    Name = priorityDto.Name,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                await _priorityRepository.AddPriority(priority);
            }
        }

        public async Task RemovePriority(PriorityDto priorityDto)
        {
            var priority = await _priorityRepository.GetPriorityById(priorityDto.PriorityId);
            if (priority != null)
            {
                _autoMapper.Map(priorityDto, priority);
                await _priorityRepository.RemovePriority(_autoMapper.Map<Priority>(priority));
            }
        }
    }
}
