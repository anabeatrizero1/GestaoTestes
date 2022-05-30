using GestaoTestes.WinApp.Compartilhado;
using GestaoTestes.Dominio.ModuloTeste;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestaoTestes.WinForm.ModuloTeste
{
    public partial class TabelaTesteControl : UserControl
    {

        public TabelaTesteControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Titulo", HeaderText = "Título"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Diciplina", HeaderText = "Disciplina"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Materia", HeaderText = "Matéria"},

                new DataGridViewTextBoxColumn {DataPropertyName = "DataCriacao", HeaderText = "Criação"}

            };

            return colunas;
        }

        internal void AtualizarRegistros(List<Teste> testes)
        {
            grid.Rows.Clear();

            foreach (var teste in testes)
            {
                grid.Rows.Add(teste.Numero, teste.Titulo, teste.Disciplina.NomeDisciplina,
                    teste.Materia.NomeMateria, teste.DataCriacao.ToShortDateString());
            }
        }

        public int ObtemNumeroTesteSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }
    }
}
