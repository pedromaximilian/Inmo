using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inmo.Models
{
    public  class Roles
    {
        public  int Id { get; set; }
        public  string Nombre { get; set; }

        public List<Roles> getAll()
        {
            List<Roles> lista = new List<Roles>();

            Roles e1 = new Roles
            {
                Id = 1,
                Nombre = "Administrador",
            };
            lista.Add(e1);
            Roles e2 = new Roles
            {
                Id = 2,
                Nombre = "Usuario",
            };
            lista.Add(e2);

            return lista;
        }






    }

}
