using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserService.RegisterUser
{
    public class RegisterUserCommand : IRequest<IdentityResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
