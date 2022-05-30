using FluentValidation;
using FluentValidation.Results;
using GestaoTestes.Dominio.ModuloDisciplina;
using GestaoTestes.Dominio.ModuloMateria;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoTestes.Infra.BancoDados.ModuloMateria
{
    public class RepositorioMateriaEmBancoDados : IRepositorioMateria
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

        #region Sql Queries
        private const string sqlInserir =
            @"INSERT INTO [TBMATERIA]
            (
                [NOME],
                [SERIE],
                [DISCIPLINA_NUMERO])
             VALUES
            (
                @NOME,
                @SERIE,
                @DISCIPLINA_NUMERO
            ); SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
            @"UPDATE [TBMATERIA]
	            SET 
		            [NOME] = @NOME,
                    [SERIE] = @SERIE,
                    [DISCIPLINA_NUMERO] = @DISCIPLINA_NUMERO
	             WHERE 
		            [NUMERO] = @NUMERO";

        private const string sqlExcluir =
            @"DELETE FROM [TBMATERIA]
		        WHERE
	                [NUMERO] = @NUMERO";

        private const string sqlSelecionarTodos =
            @"SELECT 
                MT.NUMERO,
	            MT.NOME,
	            MT.SERIE,
	            MT.DISCIPLINA_NUMERO,
	            D.NOME AS DISCIPLINA_NOME      
            FROM
                TBMATERIA AS MT INNER JOIN
	            TBDISCIPLINA AS D 
            ON 
	            MT.DISCIPLINA_NUMERO = D.NUMERO";
         
        private const string sqlSelecionarPorNumero =
            @"SELECT 
                MT.NUMERO,
	            MT.NOME,
	            MT.SERIE,
	            MT.DISCIPLINA_NUMERO,
	            D.NOME AS DISCIPLINA_NOME      
            FROM
                TBMATERIA AS MT INNER JOIN
	            TBDISCIPLINA AS D ON 
	            MT.DISCIPLINA_NUMERO = D.NUMERO
			WHERE 
				MT.[NUMERO] = @NUMERO";
        #endregion
        public ValidationResult Inserir(Materia novoRegistro)
        {
            var validador = new ValidadorMateria();

            var resultadoValidacao = validador.Validate(novoRegistro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            ConfigurarParametrosMateria(novoRegistro, comandoInsercao);

            conexaoComBanco.Open();
            var id = comandoInsercao.ExecuteScalar();
            novoRegistro.Numero = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return resultadoValidacao;

        }

        private void ConfigurarParametrosMateria(Materia materia, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("NUMERO", materia.Numero);
            comando.Parameters.AddWithValue("NOME", materia.NomeMateria);
            comando.Parameters.AddWithValue("SERIE", materia.Serie);
            comando.Parameters.AddWithValue("DISCIPLINA_NUMERO", materia.Disciplina.Numero);
        }

        public ValidationResult Editar(Materia registro)
        {
            var validador = new ValidadorMateria();

            var resultadoValidacao = validador.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            ConfigurarParametrosMateria(registro, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery();
            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Materia registro)
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

        public List<Materia> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();
            SqlDataReader leitorMateria = comandoSelecao.ExecuteReader();

            List<Materia> materias = new List<Materia>();

            while (leitorMateria.Read())
            {
                Materia materia = ConverterParaMateria(leitorMateria);

                materias.Add(materia);
            }

            conexaoComBanco.Close();

            return materias;
        }

        private Materia ConverterParaMateria(SqlDataReader leitorMateria)
        {
            var numero = Convert.ToInt32(leitorMateria["NUMERO"]);
            var nomeMateria = Convert.ToString(leitorMateria["NOME"]);
            var serie = Convert.ToString(leitorMateria["SERIE"]);

            var numeroDisciplina = Convert.ToInt32(leitorMateria["DISCIPLINA_NUMERO"]);
            var nomeDisciplina = Convert.ToString(leitorMateria["DISCIPLINA_NOME"]);


            var materia = new Materia
            {
                Numero = numero,
                NomeMateria = nomeMateria,
                Serie = serie,
                Disciplina = new Disciplina
                {
                    Numero = numeroDisciplina,
                    NomeDisciplina = nomeDisciplina
                }
                };
            
            return materia;
        }

        public Materia SelecionarPorNumero(int numero)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNumero, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("NUMERO", numero);

            conexaoComBanco.Open();
            SqlDataReader leitorMateria = comandoSelecao.ExecuteReader();

            Materia materia = null;
            if (leitorMateria.Read())
                materia = ConverterParaMateria(leitorMateria);

            conexaoComBanco.Close();

            return materia;
        }

        


    }
}
