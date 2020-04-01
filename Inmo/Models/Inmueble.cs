using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inmo.Models
{
    public class Inmueble
    {
        public int Id { get; set; }
        [Display(Name = "Dueño")]
        public int PropietarioId { get; set; }
        public string Direccion { get; set; }
        public int Ambientes { get; set; }
        public string Uso { get; set; }
        public string Tipo { get; set; }
        public float Precio { get; set; }

        public bool Disponible { get; set; }

        public Propietario Propietario;

        public List<Contrato> Contrato { get; set; }
    }
}
