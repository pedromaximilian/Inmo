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

        public ActionResult Rescindir(int id)
        {
            IList<Pago> pagos = pagoData.ObtenerPorContrato(id);
            ViewBag.Pagos = pagoData.ObtenerPorContrato(id);
            Contrato c = contratoData.ObtenerPorId(id);
            foreach (var item in pagos)
            {
                if (item.FechaVencimiento < DateTime.Now && item.Estado != "pagado")
                {
                    ViewBag.Error = "Posee pagos atrasados, regularice la situacion. No se puede rescindir el contrato";

                    return View("Details",c);
                }
            }

            c.Estado = "rescindido";
            c.FechaFin = DateTime.Now;


            contratoData.Modificacion(c);
            ViewBag.Error = "El contrato ha sido rescindido";
            return View("Details", c);
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

                bool validaFecha = inmuebleData.validaFecha(c.FechaInicio.ToShortDateString(), c.FechaFin.ToShortDateString(), c.InmuebleId);

                if (ModelState.IsValid && validaFecha)
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

        public ActionResult Renovar(int id) {

            Contrato c = contratoData.ObtenerPorId(id);

            

            return View("Renovar", c);
        }


        // POST: Contrato/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RenovarCrear(Contrato c)
        {
            int contratoId;
            int i = 1;

            try
            {

                bool validaFecha = inmuebleData.validaFecha(c.FechaInicio.ToString("yyyy-MM-dd"), c.FechaFin.ToString("yyyy-MM-dd"), c.InmuebleId);

                if (ModelState.IsValid && validaFecha)
                {
                    contratoId = contratoData.Alta(c);
                    IEnumerable<DateTime> lista = MesesEntreDias(c.FechaInicio, c.FechaFin);

                    foreach (var item in lista)
                    {
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
                ViewBag.Error = "No disponible en las fechas solicitadas. Puede ir a Contrato>Nuevo para consultar fechas";
                return View("Renovar", c);




            }
            catch (MySqlException e)
            {
                return View();
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



        public ActionResult BuscaInmuebles(DateTime inicio, DateTime fin)
        {

            IEnumerable<Inmueble> i = inmuebleData.ObtenerTodos();
            return PartialView("_InmueblesDisponiblesPartial", i);

        }

        public ActionResult buscar2(String fecha1, String fecha2)
        {

            try
            {
                if (DateTime.Parse(fecha1) < DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")))
                {
                    return PartialView("_ErrorPartial", (ViewBag.msj = "La fecha inicio no puede ser inferior a hoy"));
                }
                if (DateTime.Parse(fecha1) > DateTime.Parse(fecha2))
                {
                    return PartialView("_ErrorPartial", (ViewBag.msj = "La fecha inicio no puede ser superior a la fecha de fin"));
                }

                    IEnumerable<Inmueble> i = inmuebleData.disponiblesPorFechas(fecha1, fecha2);
                    return PartialView("_InmueblesPartial", i);
  
            }
            catch (Exception)
            {
                return PartialView("_ErrorPartial", (ViewBag.msj = "No hay resultados para su busqueda o ha ingresado mal las fechas"));
            }
        }
    }


    
}