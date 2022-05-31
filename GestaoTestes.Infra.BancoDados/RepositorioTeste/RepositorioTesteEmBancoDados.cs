using FluentValidation.Results;
using GestaoTestes.Dominio.ModuloTeste;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        private const string sqlInserir =
            @"INSERT INTO [TBTeste]
                   (
			        [Titulo],
			        [Disciplina_Numero],
			        [Materia_Numero],
			        [Recuperacao],
			        [QuantidadeQuestao]
		           )
             VALUES
                   (
		           @Titulo,
                   @Disciplina_Numero,
                   @Materia_Numero,
                   @Recuperacao, 
                   @QuantidadeQuestao
		           )";
        private const string sqlEditar =
            @"UPDATE [TBTESTE]
                SET 
	                [TITULO] = @TITULO,
                    [DISCIPLINA_NUMERO] = @DISCIPLINA_NUMERO,
                    [MATERIA_NUMERO] = @MATERIA_NUMERO,
                    [RECUPERACAO] = @RECUPERACAO,
                    [QUANTIDADEQUESTAO] = @QUANTIDADEQUESTAO
                WHERE 
		            [NUMERO] = @NUMERO";


        private const string sqlExcluir =
            @"DELETE FROM [TBTESTE]
		        WHERE
	                [NUMERO] = @NUMERO";


        private const string sqlSelecionarTodos =
            @"SELECT 
	               T.[NUMERO],
                   T.[TITULO],
                   T.[DISCIPLINA_NUMERO],
	               D.NOME AS DISCIPLINA_NOME,
                   T.[MATERIA_NUMERO],
                   M.[NOME] AS MATERIA_NOME,
                   M.[SERIE],
                   T.[RECUPERACAO],
                   T.[QUANTIDADEQUESTAO]

            FROM [TBTESTE] AS T INNER JOIN 
		         TBDISCIPLINA AS D ON T.[DISCIPLINA_NUMERO] = D.NUMERO INNER JOIN
		         TBMATERIA AS M ON T.[MATERIA_NUMERO] = M.NUMERO";

        private const string sqlSelecionarPorNumero =
            @"SELECT 
	               T.[NUMERO],
                   T.[TITULO],
                   T.[DISCIPLINA_NUMERO],
	               D.NOME AS DISCIPLINA_NOME,
                   T.[MATERIA_NUMERO],
                   M.[NOME] AS MATERIA_NOME,
                   M.[SERIE],
                   T.[RECUPERACAO],
                   T.[QUANTIDADEQUESTAO]

            FROM [TBTESTE] AS T INNER JOIN 
		         TBDISCIPLINA AS D ON T.[DISCIPLINA_NUMERO] = D.NUMERO INNER JOIN
		         TBMATERIA AS M ON T.[MATERIA_NUMERO] = M.NUMERO
            
            WHERE 
                Q.[NUMERO] = @NUMERO";

        private const string sqlSelecionarQuestoesTeste =
            @"SELECT 
	            Q.Numero,
	            Q.Enunciado,
	            Q.Disciplina_Numero,
	            Q.Materia_Numero
	        FROM TBQUESTAO AS Q INNER JOIN TBTESTE_TBQUESTAO AS TQ
	        ON Q.NUMERO = TQ.QUESTAO_NUMERO
 
            WHERE 
	            TQ.TESTE_NUMERO = 5";
        public ValidationResult Inserir(Teste novoRegistro)
        {
            var validador = new ValidadorTeste();

            var resultadoValidacao = validador.Validate(novoRegistro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            ConfigurarParametrosTeste(novoRegistro, comandoInsercao);

            conexaoComBanco.Open();
            var id = comandoInsercao.ExecuteScalar();
            novoRegistro.Numero = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        private void ConfigurarParametrosTeste(Teste novoRegistro, SqlCommand comandoInsercao)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Editar(Teste registro)
        {
            var validador = new ValidadorTeste();

            var resultadoValidacao = validador.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            ConfigurarParametrosTeste(registro, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery();
            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Teste registro)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("NUMERO", registro.Numero);

            conexaoComBanco.Open();
            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();

            var resultadoValidacao = new ValidationResult();

            if (numeroRegistrosExcluidos == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover o registro"));

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public Teste SelecionarPorNumero(int numero)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNumero, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("NUMERO", numero);

            conexaoComBanco.Open();
            SqlDataReader leitorTeste = comandoSelecao.ExecuteReader();

            Teste teste = null;
            if (leitorTeste.Read())
                teste = ConverterParaTeste(leitorTeste);

            conexaoComBanco.Close();

            return teste;
        }

        private Teste ConverterParaTeste(SqlDataReader leitorTeste)
        {
            throw new NotImplementedException();
        }

        public List<Teste> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();
            SqlDataReader leitorTeste = comandoSelecao.ExecuteReader();

            List<Teste> testes = new List<Teste>();

            while (leitorTeste.Read())
            {
                Teste teste = ConverterParaTeste(leitorTeste);

                testes.Add(teste);
            }

            conexaoComBanco.Close();

            return testes;
        }
    }
}
