using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inmo.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {


        
        public ActionResult Delete(int id)
        {
            if (!User.IsInRole("Administrador"))
            {
                ViewBag.Error = "No posee permisos para eliminar";
            }
            return View();
        }

    }

}


