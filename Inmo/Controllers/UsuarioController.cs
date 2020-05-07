using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Inmo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Inmo.Controllers
{
    public class UsuarioController : BaseController

    {

        private readonly IConfiguration configuration;
        private UsuarioData usuarioData;
        private Roles roles;
        private readonly IWebHostEnvironment environment;


        public UsuarioController(IConfiguration configuration, IWebHostEnvironment enviroment)
        {
            this.configuration = configuration;
            this.environment = enviroment;
            usuarioData = new UsuarioData(configuration);
            roles = new Roles();

        }

        // GET: Usuario
        public ActionResult Index()
        {

            var lista = usuarioData.ObtenerTodos();
            return View(lista);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            Usuario p = usuarioData.ObtenerPorId(id);
            return View(p);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {

            ViewBag.roles = RolesData.getAll();
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario u)
        {
            try
            {

                IList<Usuario> usuario = usuarioData.ObtenerTodos();

                foreach (var item in (usuario))
                {
                    if (u.Mail == item.Mail)
                    {
                        ViewBag.Error = "Error: Ya existe un usuario con ese email";
                        ViewBag.roles = RolesData.getAll();
                        return View(u);
                    }
                }



                if (ModelState.IsValid)
                {
                    string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: u.Pass,
                    salt: System.Text.Encoding.ASCII.GetBytes(configuration["Salt"]),
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 1000,
                    numBytesRequested: 256 / 8
                    ));
                    u.Pass = hashed;

                    u.RolId = User.IsInRole("Administrador") ? u.RolId : 2;
                    int res = usuarioData.Alta(u);

                    var nombreAleatorio = Guid.NewGuid();
                    if (u.AvatarFile != null && res > 0)
                    {
                        string wwwPath = environment.WebRootPath;
                        string path = Path.Combine(wwwPath, "Uploads");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        
                        string fileName = "avatar_" + u.Id + Path.GetExtension(u.AvatarFile.FileName);
                        string pathCompleto = Path.Combine(path, fileName);
                        u.Avatar = Path.Combine("/Uploads", fileName);
                        using (FileStream stream = new FileStream(pathCompleto, FileMode.Create))
                        {
                            u.AvatarFile.CopyTo(stream);
                        }
                        usuarioData.Modificacion(u);
                    }

                    

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(u);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Estoy en la excepcion");
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.roles = RolesData.getAll();
            var p = usuarioData.ObtenerPorId(id);

            return View(p);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuario u)
        {
            


            try
            {
                if (!User.IsInRole("Administrador"))
                {

                    var usuarioActual = usuarioData.ObtenerPorMail(User.Identity.Name);
                    if (usuarioActual.Id != u.Id)
                    {
                        ViewBag.Error = "No tiene permiso para modificar otro usuario";
                        return View(u);
                    }
                }
                if (u.AvatarFile != null && u.Id > 0)
                {
                    string wwwPath = environment.WebRootPath;
                    string path = Path.Combine(wwwPath, "Uploads");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    string fileName = "avatar_" + u.Id + Path.GetExtension(u.AvatarFile.FileName);
                    string pathCompleto = Path.Combine(path, fileName);
                    u.Avatar = Path.Combine("/Uploads", fileName);
                    using (FileStream stream = new FileStream(pathCompleto, FileMode.Create))
                    {
                        u.AvatarFile.CopyTo(stream);
                    }
                    
                }
                usuarioData.Modificacion(u);
                return RedirectToAction(nameof(Index));
            }
            catch (MySqlException ex)
            {
                ViewBag.Error = "No se pudo actualizar el usuario";
                return View(u);
            }
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CambioPass(int id, Usuario p)
        {

            if (!User.IsInRole("Administrador"))
            {

                var usuarioActual = usuarioData.ObtenerPorMail(User.Identity.Name);
                if (usuarioActual.Id != p.Id)
                {
                    ViewBag.Error = "No tiene permiso para modificar otro usuario";
                    return View(p);
                }
            }
            try
            {
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: p.Pass,
                    salt: System.Text.Encoding.ASCII.GetBytes(configuration["Salt"]),
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 1000,
                    numBytesRequested: 256 / 8
                    ));
                p.Pass = hashed;
                usuarioData.ModificacionPass(p);
                return RedirectToAction(nameof(Index));
            }
            catch (MySqlException ex)
            {
                return View(p);
            }
        }


        // POST: Usuario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id, Object u)
        {
            try
            {
                usuarioData.Baja(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Error = "No se pudo eliminar el usuario";
                return View();
            }
        }

    }
}