using Entidades;

namespace CalculadoraLeonelDagostino
{
    public class Numeracion
    {
        private ESistema sistema;
        private double valorNumerico;

        public ESistema Sistema
        {
            get
            {
                return sistema;
            }
        }
        public string Valor
        {
            get
            {
                return Convert.ToString(valorNumerico);
            }
        }
        private double BinarioADecimal(string valor)
        {
            if (EsBinario(valor))
            {
                double resultado = 0;
                int cantidadCaracteres = valor.Length;

                foreach (char caracter in valor)
                {
                    cantidadCaracteres--;
                    if (caracter == '1')
                    {
                        resultado += (int)Math.Pow(2, cantidadCaracteres);
                    }
                }
                return resultado;
            }
            else
            {
                return 0;
            }


        }

        public string ConvertirA(ESistema sistema)
        {
            if (sistema == this.sistema)
            {
                return Valor;
            }
            else if (sistema == ESistema.Decimal)
            {
                double resultadoDouble = BinarioADecimal(Valor);
                return Convert.ToString(resultadoDouble);


            }
            else if (sistema == ESistema.Binario)
            {
                return DecimalABinario(Valor);
                
            }

            return "Sistema no valido";



        }
        private string DecimalABinario(int valor)
        {

            if (valor < 0)
            {
                return "Numero invalido";
            }
            if (valor == 0)
            {
                return "0";
            }
            string valorBinario = "";
            int resultDiv = valor;
            int restoDiv;

            while (resultDiv > 0)
            {
                restoDiv = resultDiv % 2;
                resultDiv /= 2;
                valorBinario = restoDiv.ToString() + valorBinario;
            }
            return valorBinario;
        }
        private string DecimalABinario(string valor)
        {
            if (int.TryParse(valor, out int valorInt))
            {
                return DecimalABinario(valorInt);
            }
            else
            {
                return "Numero invalido";
            }

        }
        private bool EsBinario(string valor)
        {
            foreach (char caracter in valor)
            {
                if (caracter > '1')
                {
                    return false;
                }
            }

            return true;
        }
        private void InicializarValores(string valor, ESistema sistema)
        {
            if (sistema == ESistema.Binario)
            {
                if (EsBinario(valor))
                {
                    valorNumerico = BinarioADecimal(valor);
                }
                else
                {
                    valorNumerico = double.MinValue;
                }
            }
            else if (sistema == ESistema.Decimal)
            {
                if (double.TryParse(valor, out double decimalValor))
                {
                    valorNumerico = decimalValor;
                }
                else
                {
                    valorNumerico = double.MinValue;
                }
            }
            else
            {
                valorNumerico = double.MinValue;
            }
            this.sistema = sistema;

        }

        public Numeracion(double valor, ESistema sistema)
        {
            InicializarValores(valor.ToString(), sistema);
        }
        public Numeracion(string valor, ESistema sistema)
        {
            InicializarValores(valor, sistema);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Numeracion otraNum)
            {
                return this.Sistema == otraNum.Sistema;

            }
            return false;
        }
        public override int GetHashCode()
        {
            return Sistema.GetHashCode();
        }
        public static bool operator == (Numeracion n1, Numeracion n2)
        {
            if (ReferenceEquals(n1, n2)) 
            {
                return true;
            }

            if ((object)n1 == null || (object)n2 == null) 
            {
                return false;
            }

            return n1.Sistema == n2.Sistema;
           
            
        }
        public static bool operator != (Numeracion n1, Numeracion n2)
        {
            return !(n1 == n2);
        }

        public static bool operator == (ESistema sistema, Numeracion numeracion)
        {
            return sistema == numeracion.Sistema;
        } 
        public static bool operator != (ESistema sistema, Numeracion numeracion)
        {
            return sistema != numeracion.Sistema;
        }

        public static Numeracion operator + (Numeracion n1, Numeracion n2)
        {
            Operacion op = new Operacion(n1, n2);
            if (n1.sistema == n2.sistema)
            {
                return op.Operar('+');
            }
            else
            {
                throw new InvalidOperationException("No se pueden realizar operaciones entre un sistema y una numeración de sistemas diferentes.");
            }
        }
        public static Numeracion operator - (Numeracion n1, Numeracion n2)
        {
            Operacion op = new Operacion(n1, n2);
            if (n1.sistema == n2.sistema)
            {
                return op.Operar('-');
            }
            else
            {
                throw new InvalidOperationException("No se pueden realizar operaciones entre un sistema y una numeración de sistemas diferentes.");
            }
        }
        public static Numeracion operator * (Numeracion n1, Numeracion n2)
        {
            Operacion op = new Operacion(n1, n2);
            if (n1.sistema == n2.sistema)
            {
                return op.Operar('*');
            }
            else
            {
                throw new InvalidOperationException("No se pueden realizar operaciones entre un sistema y una numeración de sistemas diferentes.");
            }
        }public static Numeracion operator / (Numeracion n1, Numeracion n2)
        {
            Operacion op = new Operacion(n1, n2);

            if (n1.sistema == n2.sistema)
            {
                return op.Operar('/');
            }
            else
            {
                throw new InvalidOperationException("No se pueden realizar operaciones entre un sistema y una numeración de sistemas diferentes.");
            }
        }
    }
    public enum ESistema { Decimal, Binario }

}
