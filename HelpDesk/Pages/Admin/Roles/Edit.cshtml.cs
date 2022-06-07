using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.services;
using Domain.models.dto;

namespace HelpDesk.Pages.Admin.Roles
{
    public class EditModel : PageModel
    {
        private readonly IRolService _rolService;

        public EditModel(IRolService rolService)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                await _rolService.UpdateRol(Rol);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(Rol.Id))
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

        private bool RolExists(string id)
        {
            return _rolService.RolExists(id);
        }
    }
}
