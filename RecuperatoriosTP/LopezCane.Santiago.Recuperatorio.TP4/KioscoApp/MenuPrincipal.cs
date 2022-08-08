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
    public partial class MenuPrincipal : Form1
    {
        private List<Kiosco> kioscos;
        public MenuPrincipal()
        {
            InitializeComponent();
            this.kioscos = new List<Kiosco>();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                this.kioscos = GestorSQL.CargarDatos();
            }
            catch (Exception)
            {
                MessageBox.Show("No se encontraron kioscos, ejecutar Query antes de inicializar el programa");
            }

            this.listBoxKioscos.DataSource = this.kioscos;
        }

        private void buttonCargar_Click(object sender, EventArgs e)
        {
            Kiosco? kiosco = this.listBoxKioscos.SelectedItem as Kiosco;

            if(kiosco != null)
            {
                AdminKiosco formKiosco = new AdminKiosco(kiosco);
                formKiosco.ShowDialog();
            }

        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            NuevoKiosco frmNuevoKiosco = new NuevoKiosco(this.kioscos);
            frmNuevoKiosco.ShowDialog();
            this.listBoxKioscos.DataSource = null;
            this.listBoxKioscos.DataSource = this.kioscos;
        }
    }
}
