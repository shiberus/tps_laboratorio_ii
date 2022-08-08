using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Orden : Iafip
    {
        private DateTime fecha;
        private List<Producto> productos;
        private bool impuestoPagado;

        public Orden(List<Producto> productos)
        {
            this.fecha = DateTime.Now;
            this.productos = productos;
            this.impuestoPagado = false;
        }

        public Orden() : this(new List<Producto>())
        {

        }

        public int Total
        {
            get
            {
                return this.productos.Aggregate(0, (acc, producto) => acc + producto.Precio);
            }
        }

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public List<Producto> Productos { get => productos; set => productos = value; }
        public bool ImpuestosAlDia { get => this.impuestoPagado; set => this.impuestoPagado = value; }

        public float CalcularImpuestos()
        {
            return (float)this.Total * 0.21F;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(this.fecha.ToString());
            sb.AppendLine("");

            this.productos.ForEach(p => sb.AppendLine(p.ToString()));
            sb.AppendLine("");

            sb.AppendLine($"Total: ${this.Total.ToString()}");

            return sb.ToString();
        }
    }
}
