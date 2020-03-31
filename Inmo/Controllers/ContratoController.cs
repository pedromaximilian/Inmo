using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Inmo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Inmo.Controllers
{
    public class ContratoController : Controller
    {
        private readonly IConfiguration configuration;
        private InmuebleData inmuebleData;
        private InquilinoData inquilinoData;
        private ContratoData contratoData;
        private PagoData pagoData;
        public ContratoController(IConfiguration configuration)
        {
            this.configuration = configuration;
            inmuebleData = new InmuebleData(configuration);
            inquilinoData = new InquilinoData(configuration);
            contratoData = new ContratoData(configuration);
            pagoData = new PagoData(configuration);


        }



        // GET: Contrato
        public ActionResult Index()
        {

            var lista = contratoData.ObtenerTodos();


            return View(lista);
        }

        // GET: Contrato/Details/5
        public ActionResult Details(int id)
        {

            ViewBag.Pagos = pagoData.ObtenerPorContrato(id);
            Contrato c = contratoData.ObtenerPorId(id);

            return View(c);
        }

        // GET: Contrato/Create
        public ActionResult Create()
        {
            var inquilinos = inquilinoData.ObtenerTodos();
            var inmuebles = inmuebleData.ObtenerTodos();


            ViewBag.Inquilinos = inquilinos;
            ViewBag.Inmuebles = inmuebles;
            return View();
        }

        // POST: Contrato/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contrato c)
        {
            int contratoId;
            int i = 1;

            try
            {

                if (ModelState.IsValid)
                {
                    contratoId = contratoData.Alta(c);



                    IEnumerable<DateTime> lista = MesesEntreDias(c.FechaInicio, c.FechaFin);

                    foreach (var item in lista) {
                        Pago p = new Pago();
                        p.ContratoId = contratoId;
                        p.Estado = "pendiente";
                        p.FechaVencimiento = item.Date.Date;
                        p.Importe = c.Monto;
                        p.Numero = i;
                        i++;
                        pagoData.Alta(p);


                    }
                    return RedirectToAction(nameof(Index));




                }
                var inquilinos = inquilinoData.ObtenerTodos();
                var inmuebles = inmuebleData.ObtenerTodos();


                ViewBag.Inquilinos = inquilinos;
                ViewBag.Inmuebles = inmuebles;
                return View(c);




            }
            catch (MySqlException e)
            {
                return View();
            }
        }

        private static IEnumerable<DateTime> MesesEntreDias(DateTime startDate, DateTime endDate)
        {

            if (endDate < startDate)
                throw new ArgumentException("Error en las fechas ingresadas");

            while (startDate < endDate)
            {
                yield return startDate;
                startDate = startDate.AddMonths(1);
            }

        }

        // GET: Contrato/Edit/5
        public ActionResult Edit(int id)
        {
            Contrato c = contratoData.ObtenerPorId(id);
            return View(c);
        }

        // POST: Contrato/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Contrato c)
        {
            try
            {

                contratoData.Modificacion(c);
                return RedirectToAction(nameof(Index));
            }
            catch (MySqlException e)
            {
                return View();
            }
        }

        // GET: Contrato/Delete/5
        public ActionResult Delete(int id)
        {
            Contrato c = contratoData.ObtenerPorId(id);
            return View(c);
        }

        // POST: Contrato/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Contrato c)
        {
            try
            {
                contratoData.Baja(id);
                return RedirectToAction(nameof(Index));
            }
            catch (MySqlException e)
            {
                return View();
            }
        }


        
        public JsonResult buscar(string contrato)
        {
            Contrato contrato1 = contratoData.ObtenerPorId(25);

            return Json(contrato1);


        }

        
        public ActionResult buscar2(DateTime fecha1, DateTime fecha2)
        {


            Contrato contrato1 = contratoData.ObtenerPorId(25);

            return Json(contrato1);
        }
    }


    
}