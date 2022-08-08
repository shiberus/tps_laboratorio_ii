using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Producto
    {
        private string nombre;
        private string descripcion;
        private int precio;

        public Producto(string nombre, int precio, string descripcion)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
        }

        public Producto(string nombre, int precio) : this(nombre, precio, "")
        {

        }

        public Producto() : this("Producto", 1)
        {

        }

        public string Nombre { get => this.nombre; set => this.nombre = value; }
        public string Descripcion { get => this.descripcion; set => this.descripcion = value; }
        public virtual int Precio 
        { 
            get => this.precio;

            set 
            {
                if(value > 0)
                {
                    this.precio = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{this.Nombre} {this.descripcion} - ${this.Precio}";
        }

        public static bool operator ==(Producto p1, Producto p2)
        {
            return p1 is not null && p2 is not null && p1.Nombre == p2.Nombre && p1.Descripcion == p2.Descripcion;
        }
        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }
    }
}
