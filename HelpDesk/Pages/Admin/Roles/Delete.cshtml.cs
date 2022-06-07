using Microsoft.AspNetCore.Mvc.RazorPages;
using Data.services;
using Domain.models.dto;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Pages.Admin.Roles
{
    public class DeleteModel : PageModel
    {
        private readonly IRolService _rolService;

        public DeleteModel(IRolService rolService)
        {
            _rolService = rolService;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rol = await _rolService.GetRolById(id);

            if (Rol != null)
            {
                await _rolService.RemoveRol(Rol);
            }

            return RedirectToPage("./Index");
        }
    }
}
