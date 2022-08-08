using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public static class Facturador
    {
        public static string EmitirFactura(Orden orden)
        {
            return orden.ToString();
        }

        public static void GuardarFactura(Orden orden)
        {
            string nombreArchivo = orden.Fecha.ToString();

            if(!Serializador.Serializar<Orden>(orden))
            {
                throw new Exception();
            }
        }
    }
}
