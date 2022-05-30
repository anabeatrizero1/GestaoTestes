using FluentValidation;
using GestaoTestes.Dominio.ModuloTeste;
using GestaoTestes.Infra.Arquivos;
using GestaoTestes.Infra.Arquivos.Compartilhado;
using System;
using System.Collections.Generic;

namespace GestaoTestes.Arquivos.ModuloTeste
{
    public class RepositorioTesteEmArquivo : RepositorioEmArquivoBase<Teste>, IRepositorioTeste
    {
        public RepositorioTesteEmArquivo(DataContext dataContext) : base(dataContext)
        {
        }

        public override List<Teste> ObterRegistros()
        {
            return dataContext.Testes;
        }

        public override AbstractValidator<Teste> ObterValidador()
        {
            return new ValidadorTeste();
        }
    }
}
