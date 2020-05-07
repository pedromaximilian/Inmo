using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inmo.Models
{
    public class Imagen
    {
        [Key]
        public int Id { get; set; }
        
        public int InmuebleId { get; set; }
        public String Uri { get; set; }
        public IList<IFormFile> UriFile { get; set; }
    }
}
