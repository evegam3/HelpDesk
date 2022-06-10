using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Data.services;
using Domain.models.dto;

namespace HelpDesk.Pages.Admin.Priorities
{
    public class DetailsModel : PageModel
    {
        private readonly IPriorityService _priorityService;

        public DetailsModel(IPriorityService priorityService)
        {
            _priorityService = priorityService;
        }

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
    }
}
