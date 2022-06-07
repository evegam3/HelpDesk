using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Data.services;
using Domain.models.dto;

namespace HelpDesk.Pages.Admin.Roles
{
    public class CreateModel : PageModel
    {
        private readonly IRolService _rolService;

        public CreateModel(IRolService rolService)
        {
            _rolService = rolService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RolDto Rol { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            await _rolService.AddRol(Rol);

            return RedirectToPage("./Index");
        }
    }
}
