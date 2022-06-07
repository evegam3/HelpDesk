using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.context;
using Domain.models;

namespace HelpDesk.Pages.Admin.UsersRoles
{
    public class IndexModel : PageModel
    {
        private readonly HelpDeskDbContext _context;

        public IndexModel(HelpDeskDbContext context)
        {
            _context = context;
        }

        public IList<UserRole> UserRole { get;set; }

        public async Task OnGetAsync()
        {
            UserRole = await _context.UserRoles
                .Include(u => u.Role)
                .Include(u => u.User).ToListAsync();
        }
    }
}
