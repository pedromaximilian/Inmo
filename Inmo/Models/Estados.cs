using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inmo.Models
{
    public class Estados
    {
        public int id { get; set; }
        public string estado { get; set; }

        public List<Estados> estadosContrato() {
            List<Estados> lista = new List<Estados>();

            Estados e1 = new Estados
            {
                id = 1,
                estado = "normal",
            };
            lista.Add(e1);
            Estados e2 = new Estados
            {
                id = 2,
                estado = "rescindido",
            };
            lista.Add(e2);

            return lista;
        }

        public List<Estados> estadosPago()
        {
            List<Estados> lista = new List<Estados>();

            Estados e1 = new Estados
            {
                id = 1,
                estado = "pendiente",
            };
            lista.Add(e1);
            Estados e2 = new Estados
            {
                id = 2,
                estado = "pagado",
            };
            lista.Add(e2);

            return lista;
        }



        public List<Estados> usoInmueble()
        {
            List<Estados> lista = new List<Estados>();

            Estados e1 = new Estados
            {
                id = 1,
                estado = "comercial",
            };
            lista.Add(e1);
            Estados e2 = new Estados
            {
                id = 2,
                estado = " residencial",
            };
            lista.Add(e2);

            return lista;
        }

        public List<Estados> tipoInmueble()
        {
            List<Estados> lista = new List<Estados>();

            Estados e1 = new Estados
            {
                id = 1,
                estado = "deposito",
            };
            lista.Add(e1);
            Estados e2 = new Estados
            {
                id = 2,
                estado = "casa",
            };
            lista.Add(e2);
            Estados e3 = new Estados
            {
                id = 3,
                estado = "departamento",
            };
            lista.Add(e3);


            return lista;
        }
    }



}
