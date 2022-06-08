using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Data.services;
using Domain.models.dto;
using Microsoft.AspNetCore.Authorization;

namespace HelpDesk.Pages.Admin.UsersRoles
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly IUserRoleService _userRoleService;

        public DetailsModel(IUserRoleService userRoleuserService)
        {
            _userRoleService = userRoleuserService;
        }

        public UserRoleDto UserRole { get; set; }

        public async Task<IActionResult> OnGetAsync(string rolId, string userId)
        {
            if (rolId == null || userId == null)
            {
                return NotFound();
            }

            UserRole = await _userRoleService.GetRolesUsersByIds(rolId, userId);

            if (UserRole == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
