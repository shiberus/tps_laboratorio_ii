using System;
using Entidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "0";
            this.cmbOperador.SelectedIndex = 0;
            this.lstOperaciones.Items.Clear();
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando n1 = new Operando(numero1);
            Operando n2 = new Operando(numero2);
            char operadorChar = char.Parse(operador);
            return Calculadora.Operar(n1, n2, operadorChar);
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            string n1 = this.txtNumero1.Text;
            string n2 = this.txtNumero2.Text;
            string operador = (string) this.cmbOperador.SelectedItem;

            if (double.TryParse(n1, out _) && double.TryParse(n2, out _) &&
                operador != " " &&
                !(operador == "/" && n2 == "0"))
            {
                resultado = Operar(n1, n2, operador);
                this.lblResultado.Text = resultado.ToString();
                this.lstOperaciones.Items.Add($"{n1} {operador} {n2} = {resultado}");
            }
            else
            {
                this.lblResultado.Text = "Ingrese operacion valida";
            }
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            double numero;
            Operando operando = new Operando();

            if(double.TryParse(this.lblResultado.Text, out numero))
            {
                this.lblResultado.Text = operando.DecimalBinario(numero);
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando operando = new Operando();

            this.lblResultado.Text = operando.BinarioDecimal(this.lblResultado.Text);
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show("¿Esta seguro?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
