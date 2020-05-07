using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inmo.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "formato de email invalido")]
        [Required(ErrorMessage = "Campo requerido")]
        public string Mail { get; set; }

        public string Pass { get; set; }
        
        public int RolId { get; set; }
        public string Avatar { get; set; }
        public IFormFile AvatarFile { get; set; }

    }
}
