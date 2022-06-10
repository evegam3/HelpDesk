using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data.services;
using Domain.models.dto;
using Microsoft.AspNetCore.Identity;
using Domain.models;

namespace HelpDesk.Pages.Ticket
{
    public class CreateModel : PageModel
    {
        private readonly ITicketService _ticketService;
        private readonly ICategoryService _categoryService;
        private readonly IPriorityService _priorityService;
        private readonly IStatusService _statusService;
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        public CreateModel(ITicketService ticketService, ICategoryService categoryService, IPriorityService priorityService, IStatusService statusService, IUserService userService, UserManager<User> userManager)
        {
            _ticketService = ticketService;
            _categoryService = categoryService;
            _priorityService = priorityService;
            _statusService = statusService;
            _userService = userService;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["UserId"] = new SelectList(await GetUsers(), "Id", "UserName");
            ViewData["CategoryId"] = new SelectList(await GetCategories(), "CategoryId", "Name");
            ViewData["PriorityId"] = new SelectList(await GetPriorities(), "PriorityId", "Name");
            ViewData["StatusId"] = new SelectList(await GetStatuses(), "StatusId", "Description");
            return Page();
        }

        [BindProperty]
        public TicketDto Ticket { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Ticket.ReportedBy = _userManager.GetUserId(User);
            await _ticketService.AddTicket(Ticket);

            return RedirectToPage("./Index");
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            List<CategoryDto> categories = await _categoryService.GetCategories();
            return categories;
        }

        public async Task<IEnumerable<PriorityDto>> GetPriorities()
        {
            List<PriorityDto> priorities = await _priorityService.GetPriorities();
            return priorities;
        }

        public async Task<IEnumerable<StatusDto>> GetStatuses()
        {
            List<StatusDto> statuses = await _statusService.GetStatuses();
            return statuses;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            List<UserDto> users = await _userService.GetUsers();
            return users;
        }
    }
}
