using GestaoTestes.WinApp.Compartilhado;

namespace GestaoTestes.WinForm.ModuloQuestao
{
    public class ConfiguracaoToolBoxQuestao : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Questões";

        public override string TooltipInserir { get { return "Inserir uma nova questão"; } }

        public override string TooltipEditar { get { return "Editar uma questão existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma questão existente"; } }
    }
}
