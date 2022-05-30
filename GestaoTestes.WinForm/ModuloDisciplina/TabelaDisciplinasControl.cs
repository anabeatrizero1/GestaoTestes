using GestaoTestes.WinApp.Compartilhado;
using GestaoTestes.Dominio.ModuloDisciplina;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestaoTestes.WinForm.ModuloDisciplina
{
    public partial class TabelaDisciplinasControl : UserControl
    {

        public TabelaDisciplinasControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "NomeDiciplina", HeaderText = "Disciplina"},

            };

            return colunas;
        }

        public void AtualizarRegistros(List<Disciplina> disciplinas)
        {
            grid.Rows.Clear();

            foreach(var disciplina in disciplinas)
            {
                grid.Rows.Add(disciplina.Numero, disciplina.NomeDisciplina);
            }

        }

        public int ObtemNumeroDisciplinaSelecionada()
        {
            return grid.SelecionarNumero<int>(); 
        }
    }
}
