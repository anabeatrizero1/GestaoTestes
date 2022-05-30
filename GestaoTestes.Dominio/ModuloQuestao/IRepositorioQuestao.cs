using GestaoTestes.Dominio.Compratilhado;
using System.Collections.Generic;

namespace GestaoTestes.Dominio.ModuloQuestao
{
    public interface IRepositorioQuestao : IRepositorio<Questao>
    {
        void AdicionarAlternativas(Questao questaoSelecionada, List<Alternativa> alternativas);

    }
}
