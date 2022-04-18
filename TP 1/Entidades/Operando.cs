using System;
using System.Text;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        public string Numero
        {
            set 
            { 
                this.numero = ValidarOperando(value);
            }
        }

        public Operando(double numero)
        {
            this.numero = numero;
        }
        public Operando() : this(0)
        {
        }
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        private double ValidarOperando(string strNumero)
        {
            double numero;
            //Si falla el parseo, numero se setea a 0, como cumple la consigna decidi no agregar nada mas
            double.TryParse(strNumero, out numero);
            return numero;
        }

        private bool EsBinario(string binario)
        {
            bool resultado = true;

            if(binario.Length == 0)
            {
                resultado = false;
            }

            foreach(char digito in binario)
            {
                if(digito != '1' && digito != '0')
                {
                    resultado = false;
                    break;
                }
            }

            return resultado;
        }

        public string BinarioDecimal(string numero)
        {
            string resultado = "Valor invalido";
            double numeroDecimal = 0;
            int valorDeLaCifra = 1;

            if(EsBinario(numero))
            {
                for(int i = numero.Length - 1; i >= 0; i--)
                {
                    if(numero[i] == '1')
                    {
                        numeroDecimal += valorDeLaCifra;
                    }

                    valorDeLaCifra *= 2;
                }

                resultado = numeroDecimal.ToString();
            }

            return resultado;
        }

        public string DecimalBinario(double numero)
        {
            numero = Math.Abs(numero);
            StringBuilder binario = new StringBuilder();

            do
            {
                binario.Insert(0, numero % 2);
                numero = Math.Floor(numero / 2);
            } while (numero >= 1);

            return binario.ToString();
        }

        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Operando n1, Operando n2)
        {
            double resultado = double.MinValue;

            if (n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
            }

            return resultado;
        }

    }
}
