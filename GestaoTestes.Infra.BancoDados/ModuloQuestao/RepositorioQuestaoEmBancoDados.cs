using FluentValidation.Results;
using GestaoTestes.Dominio.ModuloDisciplina;
using GestaoTestes.Dominio.ModuloMateria;
using GestaoTestes.Dominio.ModuloQuestao;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoTestes.Infra.BancoDados.ModuloQuestao
{
    public class RepositorioQuestaoEmBancoDados : IRepositorioQuestao
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
            @"INSERT INTO [TBQuestao]
            (
                [Disciplina_Numero],
                [Materia_Numero]
                [Enunciado],
            )
            VALUES
            (
                @Disciplina_Numero,
                @Materia_Numero,
                @Enunciado
            ); SELECT SCOPE_IDENTITY();";

        private const string sqlEditar = 
            @"UPDATE [TBQUESTAO]
                SET
	                   [Disciplina_Numero] = @DISCIPLINA_NUMERO,
                       [Materia_Numero] = @MATERIA_NUMERO,
                       [Enunciado] = @ENUNCIADO
                 WHERE 
	                   [NUMERO] = @NUMERO";

        private const string sqlExcluir =
           @"DELETE FROM [TBQUESTAO]
		        WHERE
	                [NUMERO] = @NUMERO";

        private const string sqlSelecionarTodos =
           @"SELECT 
                Q.[NUMERO],
                Q.[ENUNCIADO],
                Q.[DISCIPLINA_NUMERO],
                D.[NOME] AS DISCIPLINA_NOME,
                Q.[MATERIA_NUMERO],
                M.[NOME] AS MATERIA_NOME,
                M.[SERIE]
            FROM
                [TBQUESTAO] AS Q INNER JOIN 
	            [TBDisciplina] AS D ON Q.[DISCIPLINA_NUMERO] = D.Numero INNER JOIN
	            [TBMateria] AS M ON Q.[MATERIA_NUMERO] = M.NUMERO";

        private const string sqlSelecionarPorNumero =
            @"SELECT 
                Q.[NUMERO],
                Q.[ENUNCIADO],
                Q.[DISCIPLINA_NUMERO],
                D.[NOME] AS DISCIPLINA_NOME,
                Q.[MATERIA_NUMERO],
                M.[NOME] AS MATERIA_NOME,
                M.[SERIE]
            FROM
                [TBQUESTAO] AS Q INNER JOIN 
	            [TBDisciplina] AS D ON Q.[DISCIPLINA_NUMERO] = D.Numero INNER JOIN
	            [TBMateria] AS M ON Q.[MATERIA_NUMERO] = M.NUMERO
            WHERE 
                Q.[NUMERO] = @NUMERO";



        public ValidationResult Inserir(Questao novoRegistro)
        {
            var validador = new ValidadorQuestao();

            var resultadoValidacao = validador.Validate(novoRegistro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            ConfigurarParametrosQuestao(novoRegistro, comandoInsercao);

            conexaoComBanco.Open();
            var id = comandoInsercao.ExecuteScalar();
            novoRegistro.Numero = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return resultadoValidacao;

        }

        
        public ValidationResult Editar(Questao registro)
        {
            var validador = new ValidadorQuestao();

            var resultadoValidacao = validador.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            ConfigurarParametrosQuestao(registro, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery();
            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Questao registro)
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

        public void AdicionarAlternativas(Questao questaoSelecionada, List<Alternativa> alternativas)
        {
            throw new NotImplementedException();
        }

        public Questao SelecionarPorNumero(int numero)
        {
            throw new NotImplementedException();
        }


        public List<Questao> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();
            SqlDataReader leitorQuestao = comandoSelecao.ExecuteReader();

            List<Questao> questoes = new List<Questao>();

            while (leitorQuestao.Read())
            {
                Questao questao = ConverterParaQuestao(leitorQuestao);

                questoes.Add(questao);
            }

            conexaoComBanco.Close();

            return questoes;
        }

        private Questao ConverterParaQuestao(SqlDataReader leitorQuestao)
        {
            var numero = Convert.ToInt32(leitorQuestao["NUMERO"]);
            var enunciado = Convert.ToString(leitorQuestao["ENUNCIADO"]);
            var questao = new Questao
            {
                Numero = numero,
                Enunciado = enunciado,
            };  
            
            var numeroDisciplina = Convert.ToInt32(leitorQuestao["DISCIPLINA_NUMERO"]);
            var nomeDisciplina = Convert.ToString(leitorQuestao["DISCIPLINA_NOME"]);
            questao.Disciplina = new Disciplina
            {
                Numero = numeroDisciplina,
                NomeDisciplina = nomeDisciplina
            };

            var numeroMateria = Convert.ToInt32(leitorQuestao["MATERIA_NUMERO"]);
            var nomeMateria = Convert.ToString(leitorQuestao["MATERIA_NOME"]);
            var serie = Convert.ToString(leitorQuestao["SERIE"]);
            questao.Materia = new Materia
            {
                Numero = numeroMateria,
                NomeMateria = nomeMateria,
                Disciplina = new Disciplina { Numero = numeroDisciplina, NomeDisciplina = nomeDisciplina },
                Serie = serie
            };

            
            return questao;
        }

        private void ConfigurarParametrosQuestao(Questao questao, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("NUMERO", questao.Numero);
            comando.Parameters.AddWithValue("ENUNCIADO", questao.Enunciado);
            comando.Parameters.AddWithValue("DISCIPLINA_NUMERO", questao.Disciplina.Numero);
            comando.Parameters.AddWithValue("DISCIPLINA_NOME", questao.Disciplina.NomeDisciplina);
            comando.Parameters.AddWithValue("MATERIA_NUMERO", questao.Materia.Numero);
            comando.Parameters.AddWithValue("MATERIA_NOME", questao.Materia.NomeMateria);
            comando.Parameters.AddWithValue("SERIE",  questao.Materia.Serie);
        }

    }
}
