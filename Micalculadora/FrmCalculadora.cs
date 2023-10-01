using System.Drawing.Text;
using CalculadoraLeonelDagostino;
using Entidades;

namespace Micalculadora
{
    public partial class FrmCalculadora : Form
    {
        private Numeracion primerOperando;
        private Numeracion segundoOperando;
        private ESistema sistema;
        private Numeracion? result;

        public FrmCalculadora()
        {
            InitializeComponent();
            primerOperando = new Numeracion(0, ESistema.Decimal);
            segundoOperando = new Numeracion(0, ESistema.Decimal);
        }


        private void btnOperar_Click(object sender, EventArgs e)
        {
            double valor1 = double.Parse(txtPrimerOperador.Text);
            double valor2 = double.Parse(txtSegundoOperador.Text);
            char operadorMatematico;
            primerOperando = new Numeracion(valor1, ESistema.Decimal);
            segundoOperando = new Numeracion(valor2, ESistema.Decimal);

            string op = cmbOperacion.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(op) && op.Length == 1)
            {

                operadorMatematico = op[0];
                Operacion operacion = new Operacion(primerOperando, segundoOperando);
                result = operacion.Operar(operadorMatematico);
                setResultado();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPrimerOperador.Text = "";
            txtSegundoOperador.Text = "";
            resultado.Text = "";
            result = null;

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void rdbBinario_CheckedChanged(object sender, EventArgs e)
        {
            sistema = ESistema.Binario;
            setResultado();

        }

        private void rdbDecimal_CheckedChanged(object sender, EventArgs e)
        {
            sistema = ESistema.Decimal;
            setResultado();

        }



        private void FrmCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Desea cerrar la calculadora?", "Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void setResultado()
        {
            if (result != null)
            {
                string resultadoMostrar = result.ConvertirA(sistema);
                resultado.Text = resultadoMostrar;
            }

        }
        private void txtPrimerOperador_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSegundoOperador_TextChanged(object sender, EventArgs e)
        {

        }
        private void FrmCalculadora_Load(object sender, EventArgs e)
        {


        }
    }
}