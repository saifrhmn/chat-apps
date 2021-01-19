using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityAndAuthorizationServer.Models;
using IdentityAndAuthorizationServer.RepositoriesInterfaces;
using Microsoft.AspNetCore.Identity;

namespace IdentityAndAuthorizationServer.Repositories
{
    public class PublicConversationRepository:IPublicConversationRepostory
    {
        private AuthenticationContext context;
        public PublicConversationRepository(AuthenticationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Object> GetMessages()
        {
            return context.PublicChatMessages.Select(x => new
            {
                Id = x.Id,
                Date = x.Date,
                Sender = string.Empty,//userManager.FindByIdAsync(x.UserId).Result.UserName,
                Message = x.Message
            }); ;
        }

        public async Task AddMessageAsync(PublicChatMessage message)
        {
            await context.PublicChatMessages.AddAsync(message);
            await context.SaveChangesAsync();
        }


        public async Task DeleteMessageAsync(PublicChatMessage message)
        {
            context.PublicChatMessages.Remove(message);
            await context.SaveChangesAsync();
        }

       
    }
}
