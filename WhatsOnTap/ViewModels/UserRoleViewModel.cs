using System;
using System.Collections.Generic;
using System.Linq;
using WhatsOnTap.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace WhatsOnTap.ViewModels
{
    public class UserRoleViewModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private string _userId;
        public string Role { get; set; }

        public UserRoleViewModel(UserManager<ApplicationUser> userManager, string userId)
        {
            _userManager = userManager;
            _userId = userId;
            GetUserRole();
        }

        public async void GetUserRole()
        {
            var currentUser = await _userManager.FindByIdAsync(_userId);
            var roles = await _userManager.GetRolesAsync(currentUser);
            Role = roles[0];
        }
    }
}
