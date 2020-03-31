using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inmo.Models
{
    public class Contrato : IValidatableObject
    {
        public int Id { get; set; }
        public int InmuebleId { get; set; }
        public int InquilinoId { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }
        public Decimal Monto { get; set; }
        public string NombreGarante { get; set; }
        public string DniGarante { get; set; }
        public string TelefonoGarante { get; set; }
        public string MailGarante { get; set; }
        public string Estado { get; set; }

        public Inmueble Inmueble { get; set; }

        public Inquilino Inquilino { get; set; }


        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if (FechaInicio > FechaFin)
            {
                yield return new ValidationResult("Existe un error en el ingreso de fechas");
            }

        }
    }
}

