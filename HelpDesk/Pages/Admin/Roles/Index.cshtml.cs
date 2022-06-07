using Microsoft.AspNetCore.Mvc.RazorPages;
using Data.services;
using Domain.models.dto;

namespace HelpDesk.Pages.Admin.Roles
{
    public class IndexModel : PageModel
    {
        private readonly IRolService _rolService;

        public IndexModel(IRolService rolService)
        {
            _rolService = rolService;
        }

        public IList<RolDto> Rol { get;set; }

        public async Task OnGetAsync()
        {
            Rol = await _rolService.GetRoles();
        }
    }
}
