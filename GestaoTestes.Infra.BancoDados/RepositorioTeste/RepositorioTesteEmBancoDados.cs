using FluentValidation.Results;
using GestaoTestes.Dominio.ModuloTeste;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoTestes.Infra.BancoDados.RepositorioTeste
{
    public class RepositorioTesteEmBancoDados : IRepositorioTeste
    {
        string enderecoBanco =
            "Data Source=(localdb)\\MSSQLLocalDB;" +
            "Initial Catalog=gestaoTestesDb;" +
            "Integrated Security=True;" +
            "Connect Timeout=30;" +
            "Encrypt=False;" +
            "TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;" +
            "MultiSubnetFailover=False";

        public ValidationResult Inserir(Teste novoRegistro)
        {
            throw new NotImplementedException();
        }
        public ValidationResult Editar(Teste registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Excluir(Teste registro)
        {
            throw new NotImplementedException();
        }

        public Teste SelecionarPorNumero(int numero)
        {
            throw new NotImplementedException();
        }

        public List<Teste> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
