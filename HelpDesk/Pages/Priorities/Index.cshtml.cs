using Microsoft.AspNetCore.Mvc.RazorPages;
using Data.services;
using Domain.models.dto;

namespace HelpDesk.Pages.Admin.Priorities
{
    public class IndexModel : PageModel
    {
        private readonly IPriorityService _priorityService;

        public IndexModel(IPriorityService priorityService)
        {
            _priorityService = priorityService;
        }

        public IList<PriorityDto> Priority { get;set; }

        public async Task OnGetAsync()
        {
            Priority = await _priorityService.GetPriorities();
        }
    }
}
