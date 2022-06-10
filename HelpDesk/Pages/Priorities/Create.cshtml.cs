using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Data.services;
using Domain.models.dto;

namespace HelpDesk.Pages.Admin.Priorities
{
    public class CreateModel : PageModel
    {
        private readonly IPriorityService _priorityService;

        public CreateModel(IPriorityService priorityService)
        {
            _priorityService = priorityService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PriorityDto Priority { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            await _priorityService.AddPriority(Priority);
            return RedirectToPage("./Index");
        }
    }
}
