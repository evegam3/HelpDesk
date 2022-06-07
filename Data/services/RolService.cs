using AutoMapper;
using Data.repositories;
using Domain.models;
using Domain.models.dto;
namespace Data.services
{
    public class RolService : IRolService
    {
        private readonly IRolRepository _rolRepository;
        private readonly IMapper _autoMapper;

        public RolService(IRolRepository rolRepository, IMapper autoMapper)
        {
            _rolRepository = rolRepository;
            _autoMapper = autoMapper;
        }

        public async Task<List<RolDto>> GetRoles()
        {
            return _autoMapper.Map<List<RolDto>>(await _rolRepository.GetRoles());
        }

        public async Task<RolDto> GetRolById(string rolId)
        {
            return _autoMapper.Map<RolDto>(await _rolRepository.GetRolById(rolId));
        }

        public bool RolExists(string rolId)
        {
            return _rolRepository.RolExists(rolId);
        }

        public async Task UpdateRol(RolDto rolDto)
        {
            var rol = await _rolRepository.GetRolById(rolDto.Id);

            if (rol != null)
            {
                _autoMapper.Map(rolDto, rol);
                await _rolRepository.UpdateRol(rol);
            }
        }

        public async Task AddRol(RolDto rolDto)
        {
            if (rolDto != null)
            {
                var rol = new Rol() {
                    Name = rolDto.Name,
                    NormalizedName = rolDto.NormalizedName,
                    ConcurrencyStamp = rolDto.ConcurrencyStamp,
                };
                await _rolRepository.AddRol(rol);
            }
        }

        public async Task RemoveRol(RolDto rolDto)
        {
            var rol = await _rolRepository.GetRolById(rolDto.Id);
            if (rol != null)
            {
                _autoMapper.Map(rolDto, rol);
                await _rolRepository.RemoveRol(_autoMapper.Map<Rol>(rol));
            }
        }
    }
}
