using FluentValidation.Results;
using GestaoTestes.Dominio.ModuloDisciplina;
using System;
using System.Windows.Forms;

namespace GestaoTestes.WinForm.ModuloDisciplina
{
    public partial class TelaCadastroDisciplinaForm : Form
    {
        private Disciplina disciplina;

        public TelaCadastroDisciplinaForm()
        {
            InitializeComponent();
        }

        public Func<Disciplina, ValidationResult> GravarRegistro { get; set; }

        public Disciplina Disciplina
        {
            get { return disciplina; }
            set 
            { 
                disciplina = value;

                txtNumero.Text = disciplina.Numero.ToString();

                txtNomeDisciplina.Text = disciplina.NomeDisciplina;
            }
        }
        #region Métodos Privados
        private void btnGravar_Click(object sender, EventArgs e)
        {
            disciplina.NomeDisciplina = txtNomeDisciplina.Text;
            
            var resultadoValidacao = GravarRegistro(disciplina);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void TelaCadastroDisciplinaForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }
        #endregion
    }
}