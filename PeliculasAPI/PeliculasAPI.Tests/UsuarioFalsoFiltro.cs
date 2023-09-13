using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPI.Tests
{
    //clase para construir Claims por defecto, para un usuario falso
    public class UsuarioFalsoFiltro: IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            context.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name,"ejemplo@hotmail.com"),
                new Claim(ClaimTypes.Email,"ejemplo@hotmail.com"),
                new Claim(ClaimTypes.NameIdentifier,"d2e6236b-d008-4065-b5cb-ee516faf5859")
            }));
            await next();
        }
    }
}
