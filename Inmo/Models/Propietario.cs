using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inmo.Models
{
    public class Propietario
    {
        [Key]
        public int? Id { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(45, ErrorMessage = "Escriba un máximo de 45 caracteres")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(45, ErrorMessage = "Escriba un máximo de 45 caracteres")]
        public string Apellido { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(50, ErrorMessage = "Escriba un máximo de 50 caracteres")]
        public string Dni { get; set; }



        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(45, ErrorMessage = "Escriba un máximo de 45 caracteres")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Ingrese un email válido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(45, ErrorMessage = "Escriba un máximo de 45 caracteres")]
        public string Telefono { get; set; }



        public List<Inmueble>? Inmuebles { get; set; }

    }
}