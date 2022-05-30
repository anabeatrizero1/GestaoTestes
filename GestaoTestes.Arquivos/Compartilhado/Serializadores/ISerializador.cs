using GestaoTestes.Infra.Arquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoTestes.Arquivos.Compartilhado.Serializadores
{
    internal interface ISerializador
    {
        DataContext CarregarDadosDoArquivo();
        void GravarDadosEmArquivo(DataContext dados);
    }
}
