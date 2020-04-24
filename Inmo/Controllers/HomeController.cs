using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Inmo.Models;
using Microsoft.Extensions.Configuration;

namespace Inmo.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;

        private ContratoData contratoData;
        public InmuebleData inmuebleData;
        public PagoData pagoData;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;

            contratoData = new ContratoData(configuration);
            inmuebleData = new InmuebleData(configuration);
            pagoData = new PagoData(configuration);

        }

        public IActionResult Index()
        {
            IEnumerable<Inmueble> total = inmuebleData.ObtenerTodos();

            IEnumerable<Inmueble> i = inmuebleData.disponiblesPorFechas(DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
            ViewBag.Disponibles = i.Count();
            ViewBag.Total = total.Count() - i.Count();

            decimal caja = 0;

            IEnumerable<Pago> cash = pagoData.ObtenerTodosHoy();

            foreach (var item in cash)
            {
                if (item.Estado =="pagado")
                {
                    caja += item.Importe;
                }
            }

            ViewBag.Caja = caja;

            int vencidos = 0;
            foreach (var item in pagoData.ObtenerTodos())
            {
                if (item.FechaVencimiento< DateTime.Now && item.Estado != "pagado")
                {
                    vencidos++;
                }
            }

            ViewBag.Vencidos = vencidos;
            

            return View();
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public ActionResult Disponibles()
        {
            try
            {
                IEnumerable<Inmueble> i = inmuebleData.disponiblesPorFechas(DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));



                return PartialView("_InmueblesTablaPartial", i);

            }
            catch (Exception)
            {

                return PartialView("_ErrorPartial", (ViewBag.msj = "No hay resultados para su busqueda. Contacte al administrador"));
            }

        }


    }
}
