using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Inmo.Controllers
{
    public class InmuebleController : BaseController
    {

        private readonly IConfiguration configuration;

        public InmuebleController(IConfiguration configuration)
        {
            this.configuration = configuration;
            inmuebleData = new InmuebleData(configuration);
            propietarioData = new PropietarioData(configuration);
            e = new Estados();

        }
        private InmuebleData inmuebleData;
        private PropietarioData propietarioData;
        private Estados e;

        // GET: Inmueble
        public ActionResult Index()
        {
            var lista = inmuebleData.ObtenerTodos();
            return View(lista);
        }

        // GET: Inmueble/Details/5
        public ActionResult Details(int id)
        {
            
            Inmueble p = inmuebleData.ObtenerPorId(id);
            ViewBag.dueño = propietarioData.ObtenerPorId(p.PropietarioId).Nombre;
            return View(p);
        }

        // GET: Inmueble/Create
        public ActionResult Create()
        {

            
            ViewBag.Tipos = e.tipoInmueble();
            ViewBag.Usos = e.usoInmueble();
            var lista = propietarioData.ObtenerTodos();

            ViewBag.lista = lista;
            return View();
        }

        // POST: Inmueble/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inmueble p)
        {
            try
            {
                int res = inmuebleData.Alta(p);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Console.WriteLine("Estoy en la excepcion");
                return View();
            }
        }

        // GET: Inmueble/Edit/5
        public ActionResult Edit(int id)
        {
            var lista = propietarioData.ObtenerTodos();
            ViewBag.Tipos = e.tipoInmueble();
            ViewBag.Usos = e.usoInmueble();
            ViewBag.lista = lista;
            var p = inmuebleData.ObtenerPorId(id);
            return View(p);
        }

        // POST: Inmueble/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Inmueble i)
        {
            
            try
            {
                inmuebleData.Modificacion(i);
                

                return RedirectToAction(nameof(Index));
            }
            catch(MySqlException ex)
            {
               
                return View(i);
            }
        }

        // POST: Inmueble/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
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