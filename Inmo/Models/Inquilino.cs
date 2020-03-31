using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inmo.Models
{
    public class Inquilino
    {
        
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string LugarTrabajo { get; set; }
        public string Estado { get; set; }

        public List<Contrato> Contrato { get; set; }

    }
}
