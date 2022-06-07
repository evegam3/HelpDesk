using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.models;
using Data.context;

namespace HelpDesk.Pages.Admin.UsersRoles
{
    public class DeleteModel : PageModel
    {
        private readonly HelpDeskDbContext _context;

        public DeleteModel(HelpDeskDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserRole UserRole { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserRole = await _context.UserRoles
                .Include(u => u.Role)
                .Include(u => u.User).FirstOrDefaultAsync(m => m.UserId == id);

            if (UserRole == null)
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

            UserRole = await _context.UserRoles.FindAsync(id);

            if (UserRole != null)
            {
                _context.UserRoles.Remove(UserRole);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
