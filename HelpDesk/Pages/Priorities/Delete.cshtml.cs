using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Data.services;
using Domain.models.dto;

namespace HelpDesk.Pages.Admin.Priorities
{
    public class DeleteModel : PageModel
    {
        private readonly IPriorityService _priorityService;

        public DeleteModel(IPriorityService priorityService)
        {
            _priorityService = priorityService;
        }

        [BindProperty]
        public PriorityDto Priority { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Priority = await _priorityService.GetPriorityById((int)id);

            if (Priority == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Priority = await _priorityService.GetPriorityById((int)id);

            if (Priority != null)
            {
                await _priorityService.RemovePriority(Priority);
            }

            return RedirectToPage("./Index");
        }
    }
}
