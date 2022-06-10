using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.services;
using Domain.models.dto;

namespace HelpDesk.Pages.Admin.Priorities
{
    public class EditModel : PageModel
    {
        private readonly IPriorityService _priorityService;

        public EditModel(IPriorityService priorityService)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _priorityService.UpdatePriority(Priority);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriorityExists(Priority.PriorityId))
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

        private bool PriorityExists(int id)
        {
            return _priorityService.PriorityExists(id);
        }
    }
}
