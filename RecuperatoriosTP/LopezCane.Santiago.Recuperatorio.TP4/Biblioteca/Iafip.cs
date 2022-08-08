using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal interface Iafip
    {
        public bool ImpuestosAlDia { get; set; }

        public float CalcularImpuestos();
    }
}
