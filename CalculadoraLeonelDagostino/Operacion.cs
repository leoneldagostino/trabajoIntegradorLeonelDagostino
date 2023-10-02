using CalculadoraLeonelDagostino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operacion
    {
        private Numeracion primerOperando;
        private Numeracion segundaOperando;
        public Numeracion PrimerOperando
        {
            get
            {
                return primerOperando;
            }
            set
            {
                primerOperando = value;
            }
        }
        public Numeracion SegundoOperando
        {
            get
            {
                return segundaOperando;
            }
            set
            {
                segundaOperando = value;
            }
        }
        public Operacion(Numeracion primerOp, Numeracion segundaOp) 
        {
            PrimerOperando = primerOp;
            SegundoOperando = segundaOp;
        }
        public Numeracion Operar(char operador)
        {
            if (PrimerOperando.Sistema == SegundoOperando.Sistema)
            {
                double valor1 = double.Parse(PrimerOperando.Valor);
                double valor2 = double.Parse(SegundoOperando.Valor);
                switch (operador) 
                {
                    case '-':
                        double resultado = valor1 - valor2;
                        return new Numeracion(resultado,PrimerOperando.Sistema);
                    case '*':
                        resultado = valor1 * valor2;
                        return new Numeracion(resultado,PrimerOperando.Sistema);
                    case '/':
                        resultado = valor1 / valor2;
                        return new Numeracion(resultado, PrimerOperando.Sistema);

                    default:
                        resultado = valor1 + valor2;
                        return new Numeracion(resultado, PrimerOperando.Sistema);
                }
            }
            else
            {
                return new Numeracion(0, ESistema.Decimal);//Posible error al mostrar en form
            }

        }
    }
}
