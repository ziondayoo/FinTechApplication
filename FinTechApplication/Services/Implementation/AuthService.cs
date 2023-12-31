﻿using FinTechApplication.Models;
using FinTechApplication.Models.DTO;
using FinTechApplication.Services.Interface;
using Microsoft.AspNetCore.Identity;

namespace FinTechApplication.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<AppUser> ValidateUser(UserLoginDTO loginDTO)
        {
            var user = await _userManager.FindByNameAsync(loginDTO.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginDTO.Password))
            {
                return user;
            }
            else
            {
                return null;
            }

        }
    }
}
