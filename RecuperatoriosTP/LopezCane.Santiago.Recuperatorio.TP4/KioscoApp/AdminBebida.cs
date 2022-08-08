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
    public partial class AdminBebida : Form1
    {
        private List<Bebida> heladera;
        public AdminBebida(List<Bebida> heladera)
        {
            InitializeComponent();
            this.labelErr.Visible = false;
            this.heladera = heladera;
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            this.labelErr.Visible = false;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(this.textBoxNombre.Text))
            {
                this.labelErr.Visible = true;
            }
            else
            {
                string nombre = this.textBoxNombre.Text;
                string descripcion = this.textBoxDesc.Text;
                int precio = (int) this.numericUpDown1.Value;

                Bebida bebida = new Bebida(nombre, precio, descripcion, Bebida.medida.chica);

                if(this.heladera.Exists((b) => b == bebida))
                {
                    MessageBox.Show("Esta bebida ya se encuentra en la heladera");
                }
                else
                {
                    this.heladera.Add(bebida);
                    this.heladera.Add(new Bebida(nombre, precio, descripcion, Bebida.medida.mediana));
                    this.heladera.Add(new Bebida(nombre, precio, descripcion, Bebida.medida.grande));

                    this.Close();
                }
            }
        }
    }
}
