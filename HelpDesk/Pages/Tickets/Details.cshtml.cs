using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.models;
using Domain.models.dto;
using Data.services;
using Microsoft.AspNetCore.Identity;

namespace HelpDesk.Pages.Tickets
{
    public class DetailsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITicketService _ticketService;
        private readonly ICategoryService _categoryService;
        private readonly IPriorityService _priorityService;
        private readonly IStatusService _statusService;
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        public DetailsModel(ITicketService ticketService, ICategoryService categoryService, IPriorityService priorityService, IStatusService statusService, IUserService userService, UserManager<User> userManager, ILogger<IndexModel> logger)
        {
            _ticketService = ticketService;
            _categoryService = categoryService;
            _priorityService = priorityService;
            _statusService = statusService;
            _userService = userService;
            _userManager = userManager;
            _logger = logger;
        }

        public TicketDto Ticket { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket = await _ticketService.GetTicketById((int)id);

            if (Ticket == null)
            {
                return NotFound();
            }
            return Page();
        }

        public string GetUserName(string userId)
        {
            return _userService.GetUserName(userId);
        }
    }
}
