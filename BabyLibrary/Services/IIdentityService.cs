using BabyLibrary.Domain.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyLibrary.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string userName, string password);
        Task<AuthenticationResult> LoginAsync(string userName, string password);
    }
}
