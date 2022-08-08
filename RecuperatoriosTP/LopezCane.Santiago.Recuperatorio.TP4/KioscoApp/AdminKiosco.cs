using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca;

namespace KioscoApp
{
    public partial class AdminKiosco : Form1
    {
        private Kiosco kiosco;
        private List<Producto> venta;
        private Task taskAfip;

        public event Action<Kiosco> Auditoria;
        public AdminKiosco(Kiosco kiosco)
        {
            this.kiosco = kiosco;
            this.venta = new List<Producto>();
            this.Auditoria += AFIP.Auditar;
            InitializeComponent();
            this.taskAfip = this.InscribirseEnAfip();
        }

        private void AdminKiosco_Load(object sender, EventArgs e)
        {
            this.labelNombre.Text = kiosco.Nombre;
            this.ActualizarRegistradora();
            this.listBoxGondola.DataSource = this.kiosco.Gondola;
            this.listBoxHeladera.DataSource = this.kiosco.Heladera;
            this.listBoxVenta.DataSource = this.venta;
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            Producto? producto = this.listBoxGondola.SelectedItem as Producto;

            if (producto != null)
            {
                this.kiosco.Gondola.Remove(producto);
                this.listBoxGondola.DataSource = null;
                this.listBoxGondola.DataSource = this.kiosco.Gondola;
            }
        }

        /// <summary>
        /// Elimina la bebida seleccionada en sus 3 tamanios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarBebida_Click(object sender, EventArgs e)
        {
            Bebida? bebida = this.listBoxHeladera.SelectedItem as Bebida;

            if (bebida != null)
            {
                this.kiosco.Heladera.RemoveAll((b) => b == bebida);
                this.listBoxHeladera.DataSource = null;
                this.listBoxHeladera.DataSource = this.kiosco.Heladera;
            }
        }

        private void btnNuevaBebida_Click(object sender, EventArgs e)
        {
            AdminBebida frmNuevaBebida = new AdminBebida(this.kiosco.Heladera);
            frmNuevaBebida.ShowDialog();
            this.listBoxHeladera.DataSource = null;
            this.listBoxHeladera.DataSource = this.kiosco.Heladera;
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            AdminProducto frmNuevoProducto = new AdminProducto(this.kiosco.Gondola);
            frmNuevoProducto.ShowDialog();
            this.listBoxGondola.DataSource = null;
            this.listBoxGondola.DataSource = this.kiosco.Gondola;
        }

        private void btnEliminarVenta_Click(object sender, EventArgs e)
        {
            this.venta.Clear();
            this.listBoxVenta.DataSource = null;
        }

        private void btnAgrProd_Click(object sender, EventArgs e)
        {
            Producto? producto = this.listBoxGondola.SelectedItem as Producto;

            if (producto != null)
            {
                this.venta.Add(producto);
                this.listBoxVenta.DataSource = null;
                this.listBoxVenta.DataSource = this.venta;
            }
        }

        private void btnAgrBebida_Click(object sender, EventArgs e)
        {
            Bebida? bebida = this.listBoxHeladera.SelectedItem as Bebida;

            if (bebida != null)
            {
                this.venta.Add(bebida);
                this.listBoxVenta.DataSource = null;
                this.listBoxVenta.DataSource = this.venta;
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            Orden orden = new Orden(this.venta);
            this.kiosco.Registradora += orden.Total;
            this.ActualizarRegistradora();
            this.kiosco.Compras.Add(orden);
            Factura frmFactura = new Factura(orden);
            frmFactura.ShowDialog();
            this.venta = new List<Producto>();
            this.listBoxVenta.DataSource = null;
        }

        /// <summary>
        /// Implementacion de multi hilo, en un thread secundario cada 15 seg la AFIP te cobra los impuestos
        /// correspondientes a tus ventas, no podes persistir los datos si no estas al dia con los impuestos,
        /// no se cobra dos veces el impuesto por una misma orden
        /// </summary>
        /// <returns></returns>
        private Task InscribirseEnAfip()
        {
            return Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(15 * 1000);

                    if(!this.kiosco.ImpuestosAlDia)
                    {
                        this.Auditoria?.Invoke(this.kiosco);
                        this.ActualizarRegistradora();
                    }
                }
            });
        }

        private void ActualizarRegistradora()
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new Action(() => this.ActualizarRegistradora()));
            }
            else
            {
                this.labelRegistradora.Text = $"${this.kiosco.Registradora}";
            }
        }

        private void btnPersistir_Click(object sender, EventArgs e)
        {
            if(!this.kiosco.ImpuestosAlDia)
            {
                MessageBox.Show("Tenes que estar al dia con los impuestos, se cobran cada 15 seg");
            }
            else
            {
                bool exito = true;
                try
                {
                    GestorSQL.ActualizarKiosco(this.kiosco);
                }
                catch
                {
                    exito = false;
                    MessageBox.Show("No se pudieron persistir los datos");
                }

                if (exito)
                {
                    MessageBox.Show("Datos guardados");
                }
            }
        }
    }
}
