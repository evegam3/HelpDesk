using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.models;

namespace HelpDesk.Pages.Admin.UsersRoles
{
    public class CreateModel : PageModel
    {
        private readonly Data.context.HelpDeskDbContext _context;

        public CreateModel(Data.context.HelpDeskDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id");
        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public UserRole UserRole { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UserRoles.Add(UserRole);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
