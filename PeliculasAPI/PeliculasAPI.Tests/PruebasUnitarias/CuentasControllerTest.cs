﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using PeliculasAPI.Controllers;
using PeliculasAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasAPI.Tests.PruebasUnitarias
{
    [TestClass]
    public class CuentasControllerTest:BasePruebas
    {
        [TestMethod]
        public async Task UsuarioCreadoPrueba()
        {
            var nombreBD = Guid.NewGuid().ToString();
            await CrearUsuarioHelper(nombreBD);

            var contexto2 = ConstruirContext(nombreBD);

            var conteo = await contexto2.Users.CountAsync();
            
            Assert.AreEqual(1, conteo);
        }

        [TestMethod]
        public async Task LoginFallido()
        {
            var nombreBD = Guid.NewGuid().ToString();
            await CrearUsuarioHelper(nombreBD);
            var userInfo = new UserInfo() { Email = "ejemplo@hotmail.com", Password = "Password12345" };

            var controller = ConstruirCuentasController(nombreBD);

            var respuesta = await controller.Login(userInfo);

            Assert.IsNull(respuesta.Value);

            var resultado = respuesta.Result as BadRequestObjectResult;
            
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public async Task LoginCorrecto()
        {
            var nombreBD = Guid.NewGuid().ToString();
            await CrearUsuarioHelper(nombreBD);
            var userInfo = new UserInfo() { Email = "ejemplo@hotmail.com", Password = "Password12345!" };

            var controller = ConstruirCuentasController(nombreBD);

            var respuesta = await controller.Login(userInfo);

            Assert.IsNotNull(respuesta.Value);
        }

        private async Task CrearUsuarioHelper(string nombreBD)
        {
            var controller = ConstruirCuentasController(nombreBD);
            var userInfo = new UserInfo() { Email = "ejemplo@hotmail.com", Password = "Password12345!" };
            await controller.Registrar(userInfo);
        }

        private CuentasController ConstruirCuentasController(string nombreDB)
        {
            var contexto = ConstruirContext(nombreDB);
            var miUserStore = new UserStore<IdentityUser>(contexto);
            var userMaganer = BuildUserManager(miUserStore);
            var mapper = ConfigurarAutoMapper();

            var httpContext = new DefaultHttpContext();
            MockAuth(httpContext);

            var signInManager = SetupSignInManager(userMaganer, httpContext);

            var miConfiguracion = new Dictionary<string, string>
            {
                {"jwt:key","ASASNMDJFNSDAKJFNSKDAJNKSADJNFKJASNDFKJASNFKJSANDFJKNSADKJNASDKJNASKDJFNKJASNGFKJNGA" }
            };

            var configutarion = new ConfigurationBuilder()
                .AddInMemoryCollection(miConfiguracion)
                .Build();

            return new CuentasController(userMaganer, configutarion, mapper, signInManager, contexto);
        }
         

        //url de codigo: https://github.com/dotnet/aspnetcore/blob/main/src/Identity/test/Identity.Test/SignInManagerTest.cs
        //url de codigo: https://github.com/dotnet/aspnetcore/blob/main/src/Identity/test/Shared/MockHelpers.cs

        private UserManager<TUser> BuildUserManager<TUser>(IUserStore<TUser> store = null)
            where TUser : class
        {
            store = store ?? new Mock<IUserStore<TUser>>().Object;
            
            var options = new Mock<IOptions<IdentityOptions>>();
            
            var idOptions = new IdentityOptions();
            idOptions.Lockout.AllowedForNewUsers = false;
            options.Setup(o => o.Value).Returns(idOptions);
            
            var userValidators = new List<IUserValidator<TUser>>();
            
            var validator = new Mock<IUserValidator<TUser>>();
            userValidators.Add(validator.Object);
            
            var pwdValidators = new List<PasswordValidator<TUser>>();
            pwdValidators.Add(new PasswordValidator<TUser>());

            var userManager = new UserManager<TUser>(store, options.Object, new PasswordHasher<TUser>(),
                userValidators, pwdValidators, new UpperInvariantLookupNormalizer(),
                new IdentityErrorDescriber(), null,
                new Mock<ILogger<UserManager<TUser>>>().Object);

            validator.Setup(v => v.ValidateAsync(userManager, It.IsAny<TUser>()))
                .Returns(Task.FromResult(IdentityResult.Success)).Verifiable();

            return userManager;
        }

        private static SignInManager<TUser> SetupSignInManager<TUser>(UserManager<TUser> manager,
            HttpContext context, ILogger logger = null, IdentityOptions identityOptions = null, 
            IAuthenticationSchemeProvider schemeProvider = null) where TUser :class
        {
            var contextAccessor = new Mock<IHttpContextAccessor>();
            contextAccessor.Setup(a => a.HttpContext).Returns(context);

            identityOptions = identityOptions ?? new IdentityOptions();

            var options = new Mock<IOptions<IdentityOptions>>();

            options.Setup(a => a.Value).Returns(identityOptions);

            var claimsFactory = new UserClaimsPrincipalFactory<TUser> (manager, options.Object);
            schemeProvider = schemeProvider ?? new Mock<IAuthenticationSchemeProvider>().Object;
            var sm = new SignInManager<TUser>(manager, contextAccessor.Object, 
                claimsFactory, options.Object, null, schemeProvider, new DefaultUserConfirmation<TUser>());
            sm.Logger = logger ?? (new Mock<ILogger<SignInManager<TUser>>>()).Object;
            return sm;
        }

        private Mock<IAuthenticationService> MockAuth(HttpContext context)
        {
            var auth = new Mock<IAuthenticationService>();
            context.RequestServices = new ServiceCollection().AddSingleton(auth.Object).BuildServiceProvider();
            return auth;
        }

    }
}
