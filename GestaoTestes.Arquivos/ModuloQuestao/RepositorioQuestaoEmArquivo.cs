using FluentValidation;
using FluentValidation.Results;
using GestaoTestes.Dominio.ModuloQuestao;
using GestaoTestes.Infra.Arquivos;
using GestaoTestes.Infra.Arquivos.Compartilhado;
using System.Collections.Generic;
using System.Linq;

namespace GestaoTestes.Arquivos.ModuloQuestao
{
    public class RepositorioQuestaoEmArquivo : RepositorioEmArquivoBase<Questao>, IRepositorioQuestao
    {
        public RepositorioQuestaoEmArquivo(DataContext dataContext) : base(dataContext)
        {
        }

        public void AdicionarAlternativas(Questao questaoSelecionada, List<Alternativa> alternativas)
        {
            foreach (var alternativa in alternativas)
            {
                questaoSelecionada.AdicionarAlternativa(alternativa);
            }

        }
        public override ValidationResult Inserir(Questao novoRegistro)
        {

            var resultadoValidacao = Validar(novoRegistro);

            if (resultadoValidacao.IsValid)
            {
                novoRegistro.Numero = ++contador;

                var registros = ObterRegistros();

                registros.Add(novoRegistro);
            }

            return resultadoValidacao;
        }
        public override ValidationResult Editar(Questao registro)
        {
            var resultadoValidacao = Validar(registro);

            if (resultadoValidacao.IsValid)
            {
                var registros = ObterRegistros();

                foreach (var item in registros)
                {
                    if (item.Numero == registro.Numero)
                    {
                        item.Atualizar(registro);
                        break;
                    }
                }
            }

            return resultadoValidacao;
        }
        public override List<Questao> ObterRegistros()
        {
            return dataContext.Questoes;
        }

        public override AbstractValidator<Questao> ObterValidador()
        {
            return new ValidadorQuestao();
        }


        private ValidationResult Validar(Questao registro)
        {
            var validator = ObterValidador();

            var resultadoValidacao = validator.Validate(registro);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            var nomeEncontrado = ObterRegistros()
                .Select(x => x.Enunciado)
               .Contains(registro.Enunciado);

            if (nomeEncontrado && registro.Numero == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Enunciado já cadastrado"));

            return resultadoValidacao;
        }
    }
}
