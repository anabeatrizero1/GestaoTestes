using FluentValidation.Results;
using GestaoTestes.Dominio.ModuloDisciplina;
using GestaoTestes.Dominio.ModuloMateria;
using GestaoTestes.Dominio.ModuloQuestao;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using System;

namespace GestaoTestes.WinForm.ModuloQuestao
{
    public partial class TelaCadastroQuestaoForm : Form
    {
        private Questao questao;
        private List<Materia> materias;

        char[] letras = new char[] { 'A', 'B', 'C', 'D'};
        int contadorLetra = 0;

        List<Alternativa> alternativasAdicionadas = new List<Alternativa>();

        public TelaCadastroQuestaoForm(List<Disciplina> disciplinas, List<Materia> materias)
        {
            InitializeComponent();

            CarregarDisciplinas(disciplinas);
            this.materias = materias;
        }

        public Questao Questao 
        {
            get { return questao; }
            set 
            {
                questao = value;

                txtNumero.Text = questao.Numero.ToString();

                cmbMateria.SelectedItem = questao.Materia;

                cmbDisciplinas.SelectedItem = questao.Disciplina;

                txtEnunciado.Text = questao.Enunciado;
            }
        }

        public List<Alternativa> AlternativasAdicionados
        {
            get
            {
                return listAlternativas.Items.Cast<Alternativa>().ToList();
            }
        }

        public Func<Questao, ValidationResult> GravarRegistro { get; set; }

        #region Métodos Privados
        private void CarregarDisciplinas(List<Disciplina> disciplinas)
        {
            cmbDisciplinas.Items.Clear();

            foreach (var item in disciplinas)
            {
                cmbDisciplinas.Items.Add(item);
            }
        }
        private void TelaCadastroQuestaoForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void cmbDisciplinas_SelectedValueChanged(object sender, EventArgs e)
        {
            Disciplina disciplinaSelecionada = (Disciplina)cmbDisciplinas.SelectedItem;
            CarregarMaterias(disciplinaSelecionada);
            cmbMateria.Enabled = true;
        }

        private void CarregarMaterias(Disciplina disciplinaSelecionada)
        {
            List<Materia> materiasDaDiscipina = materias.Where(m => m.Disciplina.Numero.Equals(disciplinaSelecionada.Numero)).ToList(); 

            cmbMateria.Items.Clear();

            foreach (var item in materiasDaDiscipina)
            {
                cmbMateria.Items.Add(item);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            questao.Disciplina = (Disciplina)cmbDisciplinas.SelectedItem;

            questao.Materia = (Materia)cmbMateria.SelectedItem;

            questao.Enunciado = txtEnunciado.Text;

            questao.Alternativas = alternativasAdicionadas;
            
            var resultadoValidacao = GravarRegistro(questao);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void btnAddAlternativa_Click(object sender, EventArgs e)
        {
            List<string> alternativas = AlternativasAdicionados.Select(a => a.Descricao).ToList();

            if (!String.IsNullOrEmpty(txtResposta.Text))
            {
                if ((contadorLetra == 0 || contadorLetra <= 4) && !alternativas.Contains(txtResposta.Text))
                {
                    Alternativa alternativa = new Alternativa();

                    alternativa.Descricao = txtResposta.Text;
                    if (checkAlternativaCorreta.Checked)
                    {
                        
                        alternativa.Letra = letras[contadorLetra];
                        alternativa.MarcarAlternativaCorreta();
                        listAlternativas.Items.Add(alternativa);
                        checkAlternativaCorreta.Checked = false;
                        checkAlternativaCorreta.Enabled = false;
                        contadorLetra++;
                    }
                    else
                    {
                        alternativa.Letra = letras[contadorLetra];
                        listAlternativas.Items.Add(alternativa);
                        contadorLetra++;
                    }

                    txtResposta.Text = "";
                    alternativasAdicionadas.Add(alternativa);
                }
            }
        }
       
        #endregion
    }
}
