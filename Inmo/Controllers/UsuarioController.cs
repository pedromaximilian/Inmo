using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmo.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
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


        public UsuarioController(IConfiguration configuration)
        {
            this.configuration = configuration;
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

            ViewBag.roles = roles.getAll();
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario u)
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
                    u.Pass = hashed;

                    usuarioData.Alta(u);

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
            var p = usuarioData.ObtenerPorId(id);

            return View(p);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuario p)
        {

            try
            {
                usuarioData.Modificacion(p);
                return RedirectToAction(nameof(Index));
            }
            catch (MySqlException ex)
            {

                return View(p);
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}