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
                if (ModelState.IsValid) {
                    int res = propietarioData.Alta(p);
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    ViewBag.Error = "verifique datos ingresados";
                    return View(p);
                }     
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
                if (ModelState.IsValid)
                {
                    propietarioData.Modificacion(p);
                    ViewBag.Exito = "Datos guardados";
                    return RedirectToAction(nameof(Index));
                }
                else {
                    ViewBag.Error = "Error al guardar";
                    return View(p);
                }
            }
            catch (MySqlException ex)
            {
                
                return View(p);
            }
        }


        // POST: Propietario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                propietarioData.Baja(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Error = "Este registro contiene datos asociados y no se puede eliminar";
                return View();
            }
        }


        // GET: Propietario/Inmuebles/5
        public ActionResult MisInmuebles(int id)
        {
            try
            {

                ViewBag.Propietario = propietarioData.ObtenerPorId(id).Nombre;
                var lista = inmuebleData.obtenerPorPropietario(id);
                return View(lista);
            }
            catch (MySqlException ez)
            {

                return View();
            }
        }

        public ActionResult Eliminar(int id)
        {
            var p = propietarioData.ObtenerPorId(id);

            return View(p);
        }


    }
}