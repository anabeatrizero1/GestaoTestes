using GestaoTestes.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoTestes.WinForm.ModuloTeste
{
    public class ConfiguracaoToolBoxTeste : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Testes";

        public override string TooltipInserir { get { return "Inserir um novo teste"; } }

        public override string TooltipEditar { get { return "Editar um teste existente"; } }

        public override string TooltipExcluir { get { return "Excluir um teste existente"; } }
    }
}
