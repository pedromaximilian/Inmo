using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inmo.Models
{
    public class Inmueble
    {
        [Key]
        public int Id { get; set; }



        [Display(Name = "Dueño")]
        [Required(ErrorMessage = "Campo requerido")]
        public int PropietarioId { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(100, ErrorMessage = "Escriba un máximo de 100 caracteres")]

        public string Direccion { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        [Range(0, 9999, ErrorMessage = "Por favor ingrese un numero")]
        public int Ambientes { get; set; }


        [Required(ErrorMessage = "Campo requerido")] 
        public string Uso { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        public string Tipo { get; set; }

        
        [Required(ErrorMessage = "Campo requerido")]
        [DataType(DataType.Currency, ErrorMessage = "Escriba un máximo de 45 caracteres")]
        [Range(0.01, 100000, ErrorMessage = "El valor debe estar entre .01 y $99999999999")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float Precio { get; set; }



        [Required(ErrorMessage = "Campo requerido")]
        public bool Disponible { get; set; }




        public Propietario Propietario;

        public List<Contrato> Contrato { get; set; }
    }
}
