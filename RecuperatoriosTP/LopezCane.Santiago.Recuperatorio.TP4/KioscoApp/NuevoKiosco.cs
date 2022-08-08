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
    public partial class NuevoKiosco : Form1
    {
        private List<Kiosco> kioscos;
        public NuevoKiosco(List<Kiosco> kioscos)
        {
            InitializeComponent();
            this.kioscos = kioscos;
            this.labelErr.Visible = false;
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            this.labelErr.Visible = false;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBoxNombre.Text))
            {
                this.labelErr.Visible = true;
            }
            else
            {
                string nombre = textBoxNombre.Text;
                int id = nombre.GetHashCode();
                int inversionInicial = (int) this.numericUpDown1.Value;

                Kiosco kiosco = new Kiosco(id, nombre, inversionInicial);

                if(this.kioscos.Exists((k) => k == kiosco))
                {
                    MessageBox.Show("Este Kiosco ya existe");
                }
                else
                {
                    this.kioscos.Add(kiosco);
                    try
                    {
                        GestorSQL.AgregarKiosco(kiosco);
                    }
                    catch
                    {
                        MessageBox.Show("No se pudo actualizar la base de datos");
                    }
                    finally
                    {
                        this.Close();
                    }
                }
            }
        }
    }
}
