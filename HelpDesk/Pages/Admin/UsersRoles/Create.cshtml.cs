using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data.services;
using Domain.models.dto;
using Microsoft.AspNetCore.Authorization;

namespace HelpDesk.Pages.Admin.UsersRoles
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly IUserRoleService _userRoleService;
        private readonly IRolService _rolService;
        private readonly IUserService _userService;

        public CreateModel(IUserRoleService userRoleuserService, IRolService rolService, IUserService userService)
        {
            _userRoleService = userRoleuserService;
            _rolService = rolService;
            _userService = userService;
        }

        public async Task<IActionResult> OnGet()
        {
            ViewData["RoleId"] = new SelectList(await GetRoles(), "Id", "Name");
            ViewData["UserId"] = new SelectList(await GetUsers(), "Id", "UserName");
            return Page();
        }

        [BindProperty]
        public UserRoleDto UserRole { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            await _userRoleService.AddRolesUsers(UserRole);
            return RedirectToPage("./Index");
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            List<UserDto> users = await _userService.GetUsers();
            return users;
        }

        public async Task<IEnumerable<RolDto>> GetRoles()
        {
            List<RolDto> roles = await _rolService.GetRoles();
            return roles;
        }
    }
}
