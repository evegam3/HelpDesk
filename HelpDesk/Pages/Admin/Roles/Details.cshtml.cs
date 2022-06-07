using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Data.services;
using Domain.models.dto;

namespace HelpDesk.Pages.Admin.Roles
{
    public class DetailsModel : PageModel
    {
        private readonly IRolService _rolService;

        public DetailsModel(IRolService rolService)
        {
            _rolService = rolService;
        }

        public RolDto Rol { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rol = await _rolService.GetRolById(id);

            if (Rol == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
