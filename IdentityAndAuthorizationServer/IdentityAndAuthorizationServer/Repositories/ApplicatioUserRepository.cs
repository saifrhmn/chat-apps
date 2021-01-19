using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityAndAuthorizationServer.Models;
using IdentityAndAuthorizationServer.Repositories_Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityAndAuthorizationServer.Repositories
{
    public class ApplicatioUserRepository : IApplicatioUserRepository
    {

        private AuthenticationContext context;
        public ApplicatioUserRepository(AuthenticationContext context)
        {
            this.context = context;
        }

        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return await context.ApplicationUsers.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task CreateApplicationUserAsync(ApplicationUser applicationUser)
        {
            await context.ApplicationUsers.AddAsync(applicationUser);
            await context.SaveChangesAsync();
        }

    }
}
