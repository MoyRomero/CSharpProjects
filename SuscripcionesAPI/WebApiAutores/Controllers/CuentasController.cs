using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiAutores.DTOs;
using WebApiAutores.Entidades;
using WebApiAutores.Servicios;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/cuentas")]
    public class CuentasController : ControllerBase
    {
        private readonly UserManager<Usuario> userManager;//Se cambió del tipo IdentityUser --> Usuario
        private readonly IConfiguration configuration;
        private readonly SignInManager<Usuario> signInManager;//Se cambió del tipo IdentityUser --> Usuario
        private readonly ServicioLlaves servicioLlaves;

        public CuentasController(UserManager<Usuario> userManager,//Se cambió del tipo IdentityUser --> Usuario
            IConfiguration configuration,
            SignInManager<Usuario> signInManager,//Se cambió del tipo IdentityUser --> Usuario
            ServicioLlaves servicioLlaves)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
            this.servicioLlaves = servicioLlaves;
        }

        [HttpPost("registrar", Name = "registrarUsuario")]
        public async Task<ActionResult<RespuestaAutenticacion>> Registrar(CredencialesUsuario credencialesUsuario)
        {
            //Se cambió del tipo IdentityUser --> Usuario
            var usuario = new Usuario { UserName = credencialesUsuario.Email, Email = credencialesUsuario.Email };

            var resultado = await userManager.CreateAsync(usuario, credencialesUsuario.Password);

            if (resultado.Succeeded)
            {
                await servicioLlaves.CrearLlave(usuario.Id, tipoLlave: Entidades.TipoLlave.Gratuita);
                return await ConstruirToken(credencialesUsuario, usuario.Id);
            }
            else
            {
                return BadRequest("Ocurrió un error." + resultado.Errors);
            }
        }

        [HttpPost("login", Name = "loginUsuario")]
        public async Task<ActionResult<RespuestaAutenticacion>> Login(CredencialesUsuario credencialesUsuario)
        {
            var resultado = await signInManager.PasswordSignInAsync(credencialesUsuario.Email, credencialesUsuario.Password,
                isPersistent: false, lockoutOnFailure: false);

            if (resultado.Succeeded)
            {
                //Linea de código para hacer búsqueda de datos de usuarios, con userManager
                var usuario = await userManager.FindByEmailAsync(credencialesUsuario.Email);
                return await ConstruirToken(credencialesUsuario, usuario.Id);
            }
            else return BadRequest("Login incorrecto");
        }

        [HttpGet("RenovarToken", Name = "renovarToken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<RespuestaAutenticacion>> Renovar()
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailClaim.Value;

            var idClaim = HttpContext.User.Claims.Where(claim => claim.Type == "id").FirstOrDefault();
            var usuarioId = idClaim.Value;

            var credencialesUsuario = new CredencialesUsuario()
            {
                Email = email
            };

            return await ConstruirToken(credencialesUsuario, usuarioId);
        }

        private async Task<RespuestaAutenticacion> ConstruirToken(CredencialesUsuario credencialesUsuario,
            string usuarioId)
        {
            var claims = new List<Claim>()
            {
                new Claim("email", credencialesUsuario.Email),
                new Claim("id", usuarioId)
            };

            var usuario = await userManager.FindByEmailAsync(credencialesUsuario.Email);
            var claimsDB = await userManager.GetClaimsAsync(usuario);

            claims.AddRange(claimsDB);

            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["llavejwt"]));
            var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);
            var Expiracion = DateTime.UtcNow.AddYears(1);

            var SecurityToken = new JwtSecurityToken(
                issuer: null, audience: null,
                claims: claims, expires: Expiracion, signingCredentials: creds);

            return new RespuestaAutenticacion
            {
                Token = new JwtSecurityTokenHandler().WriteToken(SecurityToken),
                Expiracion = Expiracion,
            };
        }

        [HttpPost("HacerAdmin", Name = "hacerAdmin")]
        public async Task<ActionResult> HacerAdmin(EditarAdminDTO editarAdminDTO)
        {
            var usuario = await userManager.FindByEmailAsync(editarAdminDTO.Email);
            await userManager.AddClaimAsync(usuario, new Claim("esAdmin", "1"));
            return NoContent();
        }

        [HttpPost("RemoverAdmin", Name = "removerAdmin")]
        public async Task<ActionResult> RemoverAdmin(EditarAdminDTO editarAdminDTO)
        {
            var usuario = await userManager.FindByEmailAsync(editarAdminDTO.Email);
            await userManager.RemoveClaimAsync(usuario, new Claim("esAdmin", "1"));
            return NoContent();
        }
    }
}
