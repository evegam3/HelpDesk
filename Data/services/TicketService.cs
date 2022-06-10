using AutoMapper;
using Data.repositories;
using Domain.Enums;
using Domain.models;
using Domain.models.dto;

namespace Data.services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _autoMapper;

        public TicketService(ITicketRepository ticketRepository, IMapper autoMapper)
        {
            _ticketRepository = ticketRepository;
            _autoMapper = autoMapper;
        }

        public async Task<List<TicketDto>> GetTickets()
        {
            return _autoMapper.Map<List<TicketDto>>(await _ticketRepository.GetTickets());
        }

        public async Task<List<TicketDto>> GetTicketsByStatus(Statuses status)
        {
            return _autoMapper.Map<List<TicketDto>>(await _ticketRepository.GetTicketsByStatus(status));
        }

        public async Task<TicketDto> GetTicketById(int ticketId)
        {
            return _autoMapper.Map<TicketDto>(await _ticketRepository.GetTicketById(ticketId));
        }

        public bool TicketExists(int ticketId)
        {
            return _ticketRepository.TicketExists(ticketId);
        }

        public async Task UpdateTicket(TicketDto ticketDto)
        {
            var ticket = await _ticketRepository.GetTicketById(ticketDto.TicketId);

            if (ticket != null)
            {
                ticket.Description = ticketDto.Description;
                ticket.CaseNumber = ticketDto.CaseNumber;
                ticket.AssignedTo = ticketDto.AssignedTo;
                ticket.PriorityId = ticketDto.PriorityId;
                ticket.CategoryId = ticketDto.CategoryId;
                ticket.StatusId = ticketDto.StatusId;
                ticket.UpdatedAt = DateTime.UtcNow;
                await _ticketRepository.UpdateTicket(ticket);
            }
        }

        public async Task AddTicket(TicketDto ticketDto)
        {
            if (ticketDto != null)
            {
                var ticket = new Ticket()
                {
                    TicketId = ticketDto.TicketId,
                    Description = ticketDto.Description,
                    CaseNumber = ticketDto.CaseNumber,
                    ReportedBy = ticketDto.ReportedBy,
                    AssignedTo = ticketDto.AssignedTo,
                    PriorityId = ticketDto.PriorityId,
                    CategoryId = ticketDto.CategoryId,
                    StatusId = ticketDto.StatusId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                };
                await _ticketRepository.AddTicket(ticket);
            }
        }

        public async Task RemoveTicket(TicketDto TicketDto)
        {
            var ticket = await _ticketRepository.GetTicketById(TicketDto.TicketId);
            if (ticket != null)
            {
                _autoMapper.Map(TicketDto, ticket);
                await _ticketRepository.RemoveTicket(_autoMapper.Map<Ticket>(ticket));
            }
        }
    }
}
