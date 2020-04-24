using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Inmo.Controllers
{
    public class PropietarioController : BaseController
        
    {

        private readonly IConfiguration configuration;
        private PropietarioData propietarioData;
        public InmuebleData inmuebleData;

        public PropietarioController(IConfiguration configuration)
        {
            this.configuration = configuration;
            propietarioData = new PropietarioData(configuration);
            inmuebleData = new InmuebleData(configuration);

        }
       
        // GET: Propietario
        public ActionResult Index()
        {

            var lista = propietarioData.ObtenerTodos();
            return View(lista);
        }

        // GET: Propietario/Details/5
        public ActionResult Details(int id)
        {
            Propietario p = propietarioData.ObtenerPorId(id);
            return View(p);
        }

        // GET: Propietario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Propietario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Propietario p)
        {
            try
            {
                int res = propietarioData.Alta(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Console.WriteLine("Estoy en la excepcion");
                return View();
            }
        }

        // GET: Propietario/Edit/5
        public ActionResult Edit(int id)
        {
            var p = propietarioData.ObtenerPorId(id);

            return View(p);
        }

        // POST: Propietario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Propietario p)
        {
            
            try
            {
                propietarioData.Modificacion(p);
                return RedirectToAction(nameof(Index));
            }
            catch (MySqlException ex)
            {
                
                return View(p);
            }
        }

        // GET: Propietario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Propietario/Delete/5
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


        // GET: Propietario/Inmuebles/5
        public ActionResult MisInmuebles(int id)
        {




            try
            {
                var lista = inmuebleData.obtenerPorPropietario(id);
                return View(lista);
            }
            catch (MySqlException ez)
            {

                return View();
            }
        }
    }
}