using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inmo.Models
{
    public class Inquilino
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(45, ErrorMessage = "Escriba un máximo de 45 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(45, ErrorMessage = "Escriba un máximo de 45 caracteres")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(45, ErrorMessage = "Escriba un máximo de 45 caracteres")]
        public string Dni { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(45, ErrorMessage = "Escriba un máximo de 45 caracteres")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(45, ErrorMessage = "Escriba un máximo de 45 caracteres")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(45, ErrorMessage = "Escriba un máximo de 45 caracteres")]
        public string LugarTrabajo { get; set; }
        
        public string Estado { get; set; }

        public List<Contrato> Contrato { get; set; }

    }
}
