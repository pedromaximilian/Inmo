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
    public class InquilinoController : BaseController
    {
        private readonly IConfiguration configuration;
        private InmuebleData inmuebleData;
        private InquilinoData inquilinoData;
        private ContratoData contratoData;

        public InquilinoController(IConfiguration configuration)
        {
            this.configuration = configuration;
            inmuebleData = new InmuebleData(configuration);
            inquilinoData = new InquilinoData(configuration);
            contratoData = new ContratoData(configuration);


        }
        


        // GET: Inquilino
        public ActionResult Index()
        {
            var lista = inquilinoData.ObtenerTodos();
            return View(lista);
        }

        // GET: Inquilino/Details/5
        public ActionResult Details(int id)
        {
            Inquilino i = inquilinoData.ObtenerPorId(id);
            return View(i);
        }

        // GET: Inquilino/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inquilino/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inquilino i)
        {
            try
            {
                inquilinoData.Alta(i);
                

                return RedirectToAction(nameof(Index));
            }
            catch(MySqlException ex)
            {

                return View();
            }
        }

        // GET: Inquilino/Edit/5
        public ActionResult Edit(int id)
        {
            Inquilino i = inquilinoData.ObtenerPorId(id);
            return View(i);

            
        }

        // POST: Inquilino/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Inquilino i)
        {
            try
            {
                inquilinoData.Modificacion(i);


                return RedirectToAction(nameof(Index));
            }
            catch (MySqlException ex)
            {
                return View();
            }
        }

        // GET: Inquilino/Delete/5
        public ActionResult Delete(int id)
        {

            Inquilino i = inquilinoData.ObtenerPorId(id);
            return View(i);
        }

        // POST: Inquilino/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Inquilino i)
        {
            try
            {
                inquilinoData.Baja(id);

                return RedirectToAction(nameof(Index));
            }
            catch (MySqlException ex)
            {
                return View();
            }
        }

        public ActionResult MisContratos(int id)
        {
            try
            {
                var lista = contratoData.ObtenerPorInquilino(id);
                return View(lista);
            }
            catch (MySqlException ez)
            {
                return View();
            }
        }
    }
}