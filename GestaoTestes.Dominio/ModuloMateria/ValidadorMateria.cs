using FluentValidation;
using System;

namespace GestaoTestes.Dominio.ModuloMateria
{
    public class ValidadorMateria : AbstractValidator<Materia>
    {
        public ValidadorMateria()
        {
            RuleFor(x => x.NomeMateria)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Serie)
                .NotNull()
                .NotEmpty();
            
            RuleFor(x => x.Disciplina)
                .NotNull()
                .NotEmpty();
        }
    }
}
