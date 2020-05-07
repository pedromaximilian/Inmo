using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inmo.Models
{
    public class Contrato : IValidatableObject
    {
        [Key]
        public int? Id { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
       
        public int InmuebleId { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        
        public int InquilinoId { get; set; }



        [Required(ErrorMessage = "Campo requerido")]
        
        [DataType(DataType.Date)]
        [Display(Name = "Inicio")]
        public DateTime FechaInicio { get; set; }



        [Required(ErrorMessage = "Campo requerido")]    
        [DataType(DataType.Date)]
        [Display(Name = "Fin")]
        public DateTime FechaFin { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [DataType(DataType.Currency, ErrorMessage = "Ingrese un precio válido")]
        [Display(Name = "Precio")]
        [Range(0.01, 100000, ErrorMessage = "El valor debe estar entre .01 y $99999999999")]
        public Decimal Monto { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(45, ErrorMessage = "Escriba un máximo de 45 caracteres")]
        [Display(Name = "Garante")]
        public string NombreGarante { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(45, ErrorMessage = "Escriba un máximo de 45 caracteres")]
        [Display(Name = "DNI Garante")]
        public string DniGarante { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(45, ErrorMessage = "Escriba un máximo de 45 caracteres")]
        [Display(Name = "Telef. Garante")]
        public string TelefonoGarante { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(45, ErrorMessage = "Escriba un máximo de 45 caracteres")]
        
        [Display(Name = "Mail Garante")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Ingrese un email válido")]
        public string MailGarante { get; set; }


        
        public string? Estado { get; set; }




        
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

