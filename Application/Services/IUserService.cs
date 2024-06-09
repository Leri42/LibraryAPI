using Application.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserService
    {
        Task<string> LoginUserAsync(LoginUserModelDto model);
        Task<IdentityResult> RegisterUserAsync(RegisterUserModelDto model);
        Task<IdentityResult> LogoutUserAsync(string userId);
    }
}
