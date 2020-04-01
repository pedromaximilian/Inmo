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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;

        private ContratoData contratoData;
        public InmuebleData InmuebleData { get; set; }

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;

            contratoData = new ContratoData(configuration);
            InmuebleData = new InmuebleData(configuration);

        }

        public IActionResult Index()
        {
            ViewBag.Contratos = contratoData.ObtenerTodos();
            ViewBag.Inmuebles = InmuebleData.ObtenerTodos();

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
    }
}
