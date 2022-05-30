using GestaoTestes.WinApp.Compartilhado;
using GestaoTestes.Dominio.ModuloMateria;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestaoTestes.WinForm.ModuloMatéria
{
    public partial class TabelaMateriasControl : UserControl
    {

        public TabelaMateriasControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Materia", HeaderText = "Matéria"},

                new DataGridViewTextBoxColumn { DataPropertyName = "NomeDiciplina", HeaderText = "Disciplina"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Serie", HeaderText = "Série"},

            };

            return colunas;
        }

        public void AtualizarRegistros(List<Materia> materias)
        {
            grid.Rows.Clear();

            foreach(var materia in materias)
            {
                grid.Rows.Add(materia.Numero, materia.NomeMateria, materia.Disciplina.NomeDisciplina, materia.Serie);
            }
        }

        public int ObtemNumeroMateriaSelecionada()
        {
            return grid.SelecionarNumero<int>(); 
        }
    }
}
