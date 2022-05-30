using FluentValidation.Results;
using GestaoTestes.Dominio.ModuloDisciplina;
using GestaoTestes.Dominio.ModuloMateria;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace GestaoTestes.WinForm.ModuloMatéria
{
    public partial class TelaCadastroMateriaForm : Form
    {
        private Materia materia;

        public TelaCadastroMateriaForm(List<Disciplina> disciplinas)
        {
            InitializeComponent();

            CarregarDisciplinas(disciplinas);
        }
       
        public Func<Materia, ValidationResult> GravarRegistros { get; set; }

        public Materia Materia
        {
            get { return materia; }
            set
            {
                materia = value;

                txtNumero.Text = materia.Numero.ToString();

                txtNomeMateria.Text = materia.NomeMateria;

                cmbDisciplinas.SelectedItem = materia.Disciplina;

                cmbSerie.SelectedItem = materia.Serie;
            }
        }

        #region Métodos Privados
        private void CarregarDisciplinas(List<Disciplina> disciplinas)
        {
            cmbDisciplinas.Items.Clear();

            foreach (var item in disciplinas)
            {
                cmbDisciplinas.Items.Add(item);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            materia.NomeMateria = txtNomeMateria.Text;

            materia.Disciplina = (Disciplina)cmbDisciplinas.SelectedItem;

            materia.Serie = cmbSerie.SelectedItem.ToString();
                 
            var resultadoValidacao = GravarRegistros(materia);

            if(resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void TelaCadastroMateriaForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }
        #endregion
    }
}
