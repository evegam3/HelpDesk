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

            CreateMap<Rol, RolDto>();
            CreateMap<RolDto, Rol>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<RolUser, RolUserDto>();
            CreateMap<RolUserDto, RolUser>();

            CreateMap<Ticket, TicketDto>();
            CreateMap<TicketDto, Ticket>();

            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();

            CreateMap<RecordTicket, RecordTicketDto>();
            CreateMap<RecordTicketDto, RecordTicket>();

            CreateMap<LogTime, LogTimeDto>();
            CreateMap<LogTimeDto, LogTime>();
        }
    }
}