using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityAndAuthorizationServer.Models;

namespace IdentityAndAuthorizationServer.Repositories_Interfaces
{
    public interface IApplicatioUserRepository
    {
        Task<ApplicationUser> FindByEmailAsync(string email);
        Task CreateApplicationUserAsync(ApplicationUser applicationUser);
    }
}
