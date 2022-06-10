using Data.services;
using Domain.models;
using Domain.models.dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpDesk.Pages.Tickets
{
    public class IndexModel : PageModel
    {
        private readonly ITicketService _ticketService;
        private readonly ICategoryService _categoryService;
        private readonly IPriorityService _priorityService;
        private readonly IStatusService _statusService;
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        public IndexModel(ITicketService ticketService, ICategoryService categoryService, IPriorityService priorityService, IStatusService statusService, IUserService userService, UserManager<User> userManager)
        {
            _ticketService = ticketService;
            _categoryService = categoryService;
            _priorityService = priorityService;
            _statusService = statusService;
            _userService = userService;
            _userManager = userManager;
        }

        public IList<TicketDto> Ticket { get;set; }

        public IPriorityService PriorityService => _priorityService;

        public async Task<IActionResult> OnGet()
        {
            Ticket = await _ticketService.GetTickets();
            return Page();
        }

        public string GetUserName(string userId)
        {
            return _userService.GetUserName(userId);
        }
    }
}
