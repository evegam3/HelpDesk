using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.models;
using Domain.models.dto;
using Microsoft.AspNetCore.Identity;
using Data.services;

namespace HelpDesk.Pages.Tickets
{
    public class EditModel : PageModel
    {
        private readonly ITicketService _ticketService;
        private readonly ICategoryService _categoryService;
        private readonly IPriorityService _priorityService;
        private readonly IStatusService _statusService;
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        public EditModel(ITicketService ticketService, ICategoryService categoryService, IPriorityService priorityService, IStatusService statusService, IUserService userService, UserManager<User> userManager)
        {
            _ticketService = ticketService;
            _categoryService = categoryService;
            _priorityService = priorityService;
            _statusService = statusService;
            _userService = userService;
            _userManager = userManager;
        }

        [BindProperty]
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

            ViewData["UserId"] = new SelectList(await GetUsers(), "Id", "UserName");
            ViewData["CategoryId"] = new SelectList(await GetCategories(), "CategoryId", "Name");
            ViewData["PriorityId"] = new SelectList(await GetPriorities(), "PriorityId", "Name");
            ViewData["StatusId"] = new SelectList(await GetStatuses(), "StatusId", "Description");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                await _ticketService.UpdateTicket(Ticket);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(Ticket.TicketId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TicketExists(int id)
        {
            return _ticketService.TicketExists(id);
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

        public string GetUserName(string userId)
        {
            return _userService.GetUserName(userId);
        }
    }
}
