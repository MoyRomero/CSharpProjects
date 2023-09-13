using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPI.Tests
{
    //Clase para evadir o pasar por encima de la restrinccion Authorization
    public class AllowAnonymousHandler : IAuthorizationHandler
    {
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            foreach(var requerimiento in context.PendingRequirements.ToList())
                context.Succeed(requerimiento);
            
            return Task.CompletedTask;
        }
    }
}
