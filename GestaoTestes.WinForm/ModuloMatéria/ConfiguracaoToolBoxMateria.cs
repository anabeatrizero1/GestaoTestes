using GestaoTestes.WinApp.Compartilhado;

namespace GestaoTestes.WinForm.ModuloMatéria
{
    public class ConfiguracaoToolBoxMateria : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Matérias";

        public override string TooltipInserir { get { return "Inserir uma nova matéria"; } }

        public override string TooltipEditar { get { return "Editar uma matéria existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma matéria existente"; } }
    }
}
