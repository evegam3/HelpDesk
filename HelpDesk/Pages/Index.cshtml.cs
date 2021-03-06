using Data.services;
using Domain.Enums;
using Domain.models;
using Domain.models.dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpDesk.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITicketService _ticketService;
        private readonly ICategoryService _categoryService;
        private readonly IPriorityService _priorityService;
        private readonly IStatusService _statusService;
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        public IndexModel(ITicketService ticketService, ICategoryService categoryService, IPriorityService priorityService, IStatusService statusService, IUserService userService, UserManager<User> userManager, ILogger<IndexModel> logger)
        {
            _ticketService = ticketService;
            _categoryService = categoryService;
            _priorityService = priorityService;
            _statusService = statusService;
            _userService = userService;
            _userManager = userManager;
            _logger = logger;
        }

        public IList<TicketDto> TicketInDev { get; set; }
        public IList<TicketDto> TicketInQA { get; set; }
        public IList<TicketDto> TicketDone { get; set; }

        public async Task<IActionResult> OnGet()
        {
            TicketInDev = await _ticketService.GetTicketsByStatus(Statuses.EnDesarrollo);
            TicketInQA = await _ticketService.GetTicketsByStatus(Statuses.EnQA);
            TicketDone = await _ticketService.GetTicketsByStatus(Statuses.Terminado);

            if (TicketInDev == null || TicketInQA == null || TicketDone == null)
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