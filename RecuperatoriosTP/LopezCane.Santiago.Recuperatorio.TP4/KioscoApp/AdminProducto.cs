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
    public partial class AdminProducto : Form1
    {
        private List<Producto> gondola;
        public AdminProducto(List<Producto> gondola)
        {
            InitializeComponent();
            this.gondola = gondola;
            this.labelErr.Visible = false;
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            this.labelErr.Visible = false;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.textBoxNombre.Text))
            {
                this.labelErr.Visible = true;
            }
            else
            {
                string nombre = this.textBoxNombre.Text;
                string descripcion = this.textBoxDesc.Text;
                int precio = (int)this.numericUpDown1.Value;

                Producto producto = new Producto(nombre, precio, descripcion);

                if (this.gondola.Exists((p) => p == producto))
                {
                    MessageBox.Show("Este producto ya se encuentra en la gondola");
                }
                else
                {
                    this.gondola.Add(producto);
                    this.Close();
                }
            }
        }
    }
}
