using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Inmo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Inmo.Controllers
{
    public class ImagenController : BaseController
    {
        private InmuebleData inmuebleData;
        private ImagenData imagenData;
        private Estados e;
        private ContratoData contratoData;
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment environment;

        public ImagenController(IConfiguration configuration, IWebHostEnvironment enviroment)
        {
            this.configuration = configuration;
            inmuebleData = new InmuebleData(configuration);
            imagenData = new ImagenData(configuration);
            contratoData = new ContratoData(configuration);
            this.environment = enviroment;
            e = new Estados();

        }
        // GET: Imagen
        public ActionResult Index()
        {
            return View();
        }

        // GET: Imagen/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Imagen/Create
        public ActionResult Create(int id)
        {
            ViewBag.Inmueble = inmuebleData.ObtenerPorId(id);

            return View();
        }

        // POST: Imagen/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Imagen i)
        {

            var x = i.UriFile.Count();

            try
            {
                
                if (i.UriFile != null && i.InmuebleId > 0)
                {

                    foreach (var item in i.UriFile)
                    {
                        Imagen nueva = new Imagen();
                        nueva.InmuebleId = i.InmuebleId;
                        var nombreAleatorio = Guid.NewGuid();
                        string wwwPath = environment.WebRootPath;
                        string path = Path.Combine(wwwPath, "Imagenes");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        string fileName = nombreAleatorio + Path.GetExtension(item.FileName);
                        string pathCompleto = Path.Combine(path, fileName);
                        nueva.Uri = Path.Combine("/Imagenes", fileName);
                        using (FileStream stream = new FileStream(pathCompleto, FileMode.Create))
                        {
                            item.CopyTo(stream);
                        }
                        imagenData.Alta(nueva);

                    }
 
                }

                return RedirectToAction("Index", "Inmueble");
            }
            catch
            {
                return View();
            }
        }

        // GET: Imagen/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Imagen/Edit/5
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

        // GET: Imagen/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Imagen/Delete/5
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