using System;
using DristorApp.Data.DTOs.User;
using Microsoft.AspNetCore.Identity;

namespace DristorApp.UserManagementService
{

    public interface IUserManagementService
    {
        public Task<IdentityResult> RegisterUserAsync(RegisterUserDTO dto);
        public Task<string?> LoginUserAsync(LoginUserDTO dto);
    }
}
