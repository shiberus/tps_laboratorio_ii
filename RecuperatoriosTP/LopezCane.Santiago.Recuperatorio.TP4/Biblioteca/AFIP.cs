using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public static class AFIP
    {
        /// <summary>
        /// Cobra los impuestos al kiosco, en caso de no ser posible 
        /// lo elimina de la base de datos, clausurado por evasor
        /// </summary>
        /// <param name="kiosco"></param>
        public static void Auditar(Kiosco kiosco)
        {
            try
            {
                kiosco.PagarImpuestos();
            }
            catch (AfipException)
            {
                GestorSQL.EliminarKiosco(kiosco);
            }
            finally
            {
                100.NoHacerNada();
            }
        }
    }
}
