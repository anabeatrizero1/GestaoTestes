using GestaoTestes.WinApp.Compartilhado;
using GestaoTestes.Dominio.ModuloQuestao;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestaoTestes.WinForm.ModuloQuestao
{
    public partial class TabelaQuestoesControl : UserControl
    {

        public TabelaQuestoesControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Diciplina", HeaderText = "Disciplina"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Materia", HeaderText = "Matéria"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Enunciado", HeaderText = "Questão"},

            };

            return colunas;
        }

        public void AtualizarRegistros(List<Questao> questoes)
        {
            grid.Rows.Clear();

            foreach (var questao in questoes)
            {
                grid.Rows.Add(questao.Numero, questao.Disciplina.NomeDisciplina, questao.Materia.NomeMateria, questao.Enunciado);
            }
        }

        public int ObtemNumeroQuestaoSelecionada()
        {
            return grid.SelecionarNumero<int>();
        }
    }
}
