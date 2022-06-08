using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Data.services;
using Domain.models.dto;
using Microsoft.AspNetCore.Authorization;

namespace HelpDesk.Pages.Admin.UsersRoles
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly IUserRoleService _userRoleService;

        public DeleteModel(IUserRoleService userRoleuserService)
        {
            _userRoleService = userRoleuserService;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string rolId, string userId)
        {
            if (rolId == null || userId == null)
            {
                return NotFound();
            }

            UserRole = await _userRoleService.GetRolesUsersByIds(rolId, userId);

            if (UserRole != null)
            {
                await _userRoleService.RemoveRolesUsers(UserRole);
            }

            return RedirectToPage("./Index");
        }
    }
}
