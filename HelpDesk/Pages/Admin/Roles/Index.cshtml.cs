using Microsoft.AspNetCore.Mvc.RazorPages;
using Data.services;
using Domain.models.dto;
using Microsoft.AspNetCore.Authorization;

namespace HelpDesk.Pages.Admin.Roles
{
    [Authorize(Roles = "Admin")]
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
