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
    public class PagoController : BaseController
    {
        private readonly IConfiguration configuration;
        private PagoData pagoData;
        private ContratoData contratoData;

        public PagoController(IConfiguration configuration)
        {
            this.configuration = configuration;
            pagoData = new PagoData(configuration);
            contratoData = new ContratoData(configuration);

        }
        
        // GET: Pago
        public ActionResult Index()
        {
            var lista = pagoData.ObtenerTodos();
            return View(lista);
        }

        // GET: Pago/Details/5
        public ActionResult Details(int id)
        {
            Pago pago = pagoData.ObtenerPorId(id);
            return View(pago);
        }

        // GET: Pago/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pago/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pago p)
        {
            try
            {
                

                return RedirectToAction(nameof(Index));
            }
            catch(MySqlException ex)
            {
                return View();
            }
        }

        // GET: Pago/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pago/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pago/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pago/Delete/5
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

        // GET: Pago/Pagar/5
        public ActionResult Pagar(int id)
        {
            try
            {
                int contrato = (pagoData.ObtenerPorId(id)).ContratoId;

                pagoData.Pagar(id);
                return RedirectToAction("Details", "Contrato", new { id = contrato });
            }
            catch (MySqlException ex)
            {

                throw;
            }
        }
    }
}