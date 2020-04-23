using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inmo.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Pass { get; set; }
        public string Salt { get; set; }
        public int RolId { get; set; }
        public int Estado { get; set; }

    }
}
