using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.context;
using Domain.models;

namespace HelpDesk.Pages.Admin.UsersRoles
{
    public class DetailsModel : PageModel
    {
        private readonly HelpDeskDbContext _context;

        public DetailsModel(HelpDeskDbContext context)
        {
            _context = context;
        }

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
    }
}
