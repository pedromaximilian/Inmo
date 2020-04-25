using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inmo.Models
{
    public static class RolesData
    {

        private static List<Roles> Lista { get; set; }

        static  RolesData()
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

            Lista = lista;
        }

        public static List<Roles> getAll() {
            return Lista; 
        }

        public static Roles getById(int id)
        {
            Roles r = new Roles();
            r = Lista.Find(x => x.Id == id);
            return r;

        }
    }
}
