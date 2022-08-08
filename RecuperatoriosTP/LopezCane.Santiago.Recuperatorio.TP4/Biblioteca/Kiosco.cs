using System;
using System.Collections.Generic;

namespace Biblioteca
{
    public class Kiosco : Iafip
    {
        private int id;
        private string nombre;
        private int registradora;
        private List<Producto> gondola;
        private List<Bebida> heladera;
        private List<Orden> compras;

        public Kiosco(int id, string nombre, int registradora)
        {
            this.id = id;
            this.nombre = nombre;
            this.registradora = registradora;
            this.gondola = new List<Producto>();
            this.heladera = new List<Bebida>();
            this.compras = new List<Orden>();
        }

        public Kiosco(int id, string nombre) : this(id, nombre, 0)
        {

        }

        public int ID { get { return id; } }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Registradora { get => registradora; set => registradora = value; }
        public List<Producto> Gondola { get => gondola; set => gondola = value; }
        public List<Bebida> Heladera { get => heladera; set => heladera = value; }
        public List<Orden> Compras { get => compras; set => compras = value; }
        public bool ImpuestosAlDia
        {
            get
            {
                bool resultado = true;

                foreach (Orden item in this.Compras)
                {
                    if (!item.ImpuestosAlDia)
                    {
                        resultado = false;
                    }
                }

                return resultado;
            }

            set
            {
                foreach (Orden item in this.Compras)
                {
                    item.ImpuestosAlDia = value;
                }
            }
        }

        public float CalcularImpuestos()
        {
            float resultado = 0;

            foreach (Orden item in this.Compras)
            {
                resultado += item.CalcularImpuestos();
            }

            return resultado;
        }

        public void PagarImpuestos()
        {
            if(this.Registradora < this.CalcularImpuestos())
            {
                throw new AfipException();
            }

            this.Registradora -= (int) this.CalcularImpuestos();

            this.ImpuestosAlDia = true;
        }

        public override string ToString()
        {
            return this.Nombre;
        }

        public static bool operator ==(Kiosco k1, Kiosco k2)
        {
            return k1 is not null && k2 is not null && k1.Nombre == k2.Nombre;
        }

        public static bool operator !=(Kiosco k1, Kiosco k2)
        {
            return !(k1 == k2);
        }
    }
}
