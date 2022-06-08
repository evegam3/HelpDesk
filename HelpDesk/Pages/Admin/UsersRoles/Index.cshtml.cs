using Microsoft.AspNetCore.Mvc.RazorPages;
using Data.services;
using Domain.models.dto;
using Microsoft.AspNetCore.Authorization;

namespace HelpDesk.Pages.Admin.UsersRoles
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IUserRoleService _userRoleService;

        public IndexModel(IUserRoleService userRoleuserService)
        {
            _userRoleService = userRoleuserService;
        }

        public IList<UserRoleDto> UserRole { get;set; }

        public async Task OnGetAsync()
        {
            UserRole = await _userRoleService.GetUserRoles();
        }
    }
}
