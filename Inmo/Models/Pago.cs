using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inmo.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public int ContratoId { get; set; }
        public int Numero { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaVencimiento { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaPago { get; set; }
        public Decimal Importe { get; set; }
        public string Estado { get; set; }
    }
}
