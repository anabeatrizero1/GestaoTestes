using FluentValidation.Results;
using GestaoTestes.Dominio.ModuloDisciplina;
using GestaoTestes.Dominio.ModuloMateria;
using GestaoTestes.Dominio.ModuloQuestao;
using GestaoTestes.Dominio.ModuloTeste;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoTestes.WinForm.ModuloTeste
{
    public partial class TelaCadastroTesteForm : Form
    {
        private Teste teste;
        private List<Materia> materias;
        private List<Questao> questoesDoTeste;
        private List<Disciplina> disciplinas;
        private List<Questao> todasQuestoes;


        public TelaCadastroTesteForm(List<Disciplina> disciplinas, List<Materia> materias, List<Questao> questoes)
        {
            InitializeComponent();

            this.disciplinas = disciplinas;
            this.materias = materias;
            this.todasQuestoes = questoes;
            this.dataCriacao.Value = DateTime.Now;

            CarregarDisciplinas(this.disciplinas);

        }

        public Func<Teste, ValidationResult> GravarRegistro { get; set; }


        public Teste Teste 
        {
            get {return teste; }
            set 
            {
                teste = value;
                txtNumero.Text = teste.Numero.ToString();
                cmbDisciplinas.SelectedItem = teste.Disciplina;
                

            }
        }

        private void TelaCadastroTesteForm_Load(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void cmbDisciplina_SelectedValueChanged(object sender, EventArgs e)
        {
            Disciplina disciplinaSelecionada = (Disciplina)cmbDisciplinas.SelectedItem;
            CarregarMaterias(disciplinaSelecionada);
        }

       

        private void checkProvaRecuperacao_CheckedChanged(object sender, EventArgs e)
        {
            Disciplina disciplinaSelecionada = (Disciplina)cmbDisciplinas.SelectedItem;

            List<Materia> materiasDaDisciplina = materias.Where(m => m.Disciplina.Equals(disciplinaSelecionada)).ToList();

            if (checkProvaRecuperacao.Checked)
            {
                cmbMateria.Enabled = false;
                numericQtdQuestoes.Maximum = materiasDaDisciplina.Count();
            }
            else
            {
                cmbMateria.Enabled = true;
            }
        }

        private void qtdQuestoes_ClientSizeChanged(object sender, EventArgs e)
        {
           
        }

        private void CarregarQuestoes(List<Questao> questoesDoTeste)
        {
            
            for (int i = 0; i < int.Parse(numericQtdQuestoes.Value.ToString()); i++)
            {
                listQuestoes.Items.Add(questoesDoTeste[i]);
            }

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            teste.Titulo = txtTitulo.Text;

            teste.Disciplina = (Disciplina)cmbDisciplinas.SelectedItem;

            if(!checkProvaRecuperacao.Checked)
                teste.Materia = (Materia)cmbMateria.SelectedItem;
            else
                teste.Materia = null;

            teste.Questoes = questoesDoTeste;
            
            var resultadoValidacao = GravarRegistro(teste);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }

        }

        private void numericQtdQuestoes_Click(object sender, EventArgs e)
        {
            Disciplina disciplinaSelecionada = (Disciplina)cmbDisciplinas.SelectedItem;

            listQuestoes.Items.Clear();

            if (cmbMateria.Enabled == false)
            {
                questoesDoTeste = todasQuestoes.Where(q => q.Disciplina.Equals(disciplinaSelecionada)).ToList();
            }
            else
            {
                Materia materiaSelecionada = (Materia)cmbMateria.SelectedItem;
                questoesDoTeste = todasQuestoes.
                    Where(q => q.Disciplina.Equals(disciplinaSelecionada)).
                    Where(x => x.Materia.Equals(materiaSelecionada)).
                    ToList();
            }

            var random = new Random();

            questoesDoTeste = questoesDoTeste.OrderBy(item => random.Next()).ToList();

            CarregarQuestoes(questoesDoTeste);
        }

        private void cmbMateria_SelectedValueChanged(object sender, EventArgs e)
        {
            Materia materiaSelecionada = (Materia)cmbMateria.SelectedItem;
            numericQtdQuestoes.Enabled = true;

            decimal qtdquestoes = todasQuestoes.
                    Where(x => x.Materia.Equals(materiaSelecionada)).
                    ToList().Count;

            numericQtdQuestoes.Maximum = qtdquestoes;
                   

        }
        private void CarregarDisciplinas(List<Disciplina> disciplinas)
        {
            cmbDisciplinas.Items.Clear();

            foreach (var item in disciplinas)
            {
                cmbDisciplinas.Items.Add(item);
            }
        }
        private void CarregarMaterias(Disciplina disciplinaSelecionada)
        {
            List<Materia> materiasDaDisciplina = materias.Where(m => m.Disciplina.Equals(disciplinaSelecionada)).ToList();

            cmbMateria.Items.Clear();

            foreach (var item in materiasDaDisciplina)
            {
                cmbMateria.Items.Add(item);
            }

        }
    }
}
