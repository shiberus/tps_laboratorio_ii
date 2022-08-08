using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Bebida : Producto
    {
        public enum medida { chica, mediana, grande }

        private medida tamanio;

        public Bebida(string nombre, int precio, string descripcion, medida tamanio) : base(nombre, precio, descripcion)
        {
            this.tamanio = tamanio;
        }

        public Bebida(string nombre, int precio, medida tamanio) : this(nombre, precio, "", tamanio)
        {

        }
        public medida Tamanio { get => tamanio; set => tamanio = value; }
        public int PrecioBase { get => base.Precio; }

        /// <summary>
        /// Devuelve el precio ajustado al tamanio de la bebida, la mediana sale el doble que la chica, la grande el triple.
        /// </summary>
        public override int Precio
        {
            get
            {
                return base.Precio + base.Precio * (int) this.tamanio;
            }

            set => base.Precio = value; 
        }



        public override string ToString()
        {
            return $"{this.Nombre} {this.Descripcion} - {this.tamanio.ToString()} - ${this.Precio}";
        }
    }
}
