using GestaoTestes.WinApp.Compartilhado;

namespace GestaoTestes.WinForm.ModuloDisciplina
{
    public class ConfiguracaoToolBoxDisciplina : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Disciplinas";

        public override string TooltipInserir { get { return "Inserir uma nova disciplina"; } }

        public override string TooltipEditar { get { return "Editar uma disciplina existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma disciplina existente"; } }
    }
}