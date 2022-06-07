using AutoMapper;
using Domain.models;
using Domain.models.dto;

namespace Data
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Status, StatusDto>();
            CreateMap<StatusDto, Status>();

            CreateMap<Priority, PriorityDto>();
            CreateMap<PriorityDto, Priority>();

            CreateMap<Deparment, DeparmentDto>();
            CreateMap<DeparmentDto, Deparment>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Ticket, TicketDto>();
            CreateMap<TicketDto, Ticket>();

            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();

            CreateMap<RecordTicket, RecordTicketDto>();
            CreateMap<RecordTicketDto, RecordTicket>();

            CreateMap<LogTime, LogTimeDto>();
            CreateMap<LogTimeDto, LogTime>();

            CreateMap<Rol, RolDto>();
            CreateMap<RolDto, Rol>();

            CreateMap<UserRole, UserRoleDto>();
            CreateMap<UserRoleDto, UserRole>();
        }
    }
}