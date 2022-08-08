using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca;

namespace KioscoApp
{
    public partial class Factura : Form1
    {
        private Orden orden;
        public Factura(Orden orden)
        {
            this.orden = orden;
            InitializeComponent();
        }

        private void Factura_Load(object sender, EventArgs e)
        {
            this.richTextBox1.Text = Facturador.EmitirFactura(orden);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool exito = true;
            try
            {
                Facturador.GuardarFactura(orden);
            }
            catch
            {
                exito = false;
                MessageBox.Show("Error al persistir datos");
            }

            if (exito)
            {
                MessageBox.Show("Guardado");
            }

            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
