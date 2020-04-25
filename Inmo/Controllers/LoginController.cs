using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Inmo.Models;
using Inmo.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Inmo.Controllers
{
    
    public class LoginController : Controller
    {
        private readonly IConfiguration configuration;
        private UsuarioData usuarioData;
        private Roles rol;


        public LoginController(IConfiguration configuration)
        {
            this.configuration = configuration;
            usuarioData = new UsuarioData(configuration);
            rol = new Roles();
            

        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: u.Pass,
                    salt: System.Text.Encoding.ASCII.GetBytes(configuration["Salt"]),
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 1000,
                    numBytesRequested: 256 / 8
                    ));


                    var usuario = usuarioData.ObtenerPorMail(u.Mail);



                    if (usuario == null || usuario.Pass != hashed)
                    {
                        ModelState.AddModelError("", "El email o la clave no son correctas");
                        return View();
                    }

                    var claims = new List<Claim>
                    {
                        new Claim("Id", usuario.Id.ToString()),
                        new Claim(ClaimTypes.Name, usuario.Mail),
                        new Claim(ClaimTypes.Role, RolesData.getById(usuario.RolId).Nombre)

                    
                    };

                    if (RolesData.getById(usuario.RolId).Nombre == "Administrador")
                    {
                        claims.Add(
                            new Claim("Admin", "Admin")
                            );
                    }


                    var claimsIdentity = new ClaimsIdentity(
                        claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction(nameof(Index), "Home");
                }
                else
                {
                    return View(u);
                }
            }
            catch (Exception)
            {

                throw;
            }
        
        }



            public async Task<ActionResult> Logout() {

            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("index", "Home");
        }
    }
}