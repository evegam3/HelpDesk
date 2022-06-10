using Domain.Enums;
using Domain.models.dto;

namespace Data.services
{
    public interface ITicketService
    {
        public Task<List<TicketDto>> GetTickets();
        public Task<List<TicketDto>> GetTicketsByStatus(Statuses status);
        public bool TicketExists(int TicketDtoId);
        public Task<TicketDto> GetTicketById(int TicketDtoId);
        public Task UpdateTicket(TicketDto TicketDto);
        public Task AddTicket(TicketDto TicketDto);
        public Task RemoveTicket(TicketDto TicketDto);
    }
}