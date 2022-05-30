using FluentValidation;
using System;

namespace GestaoTestes.Dominio.ModuloDisciplina
{
    public class ValidadorDisciplina : AbstractValidator<Disciplina>
    {
        public ValidadorDisciplina()
        {
            RuleFor(x => x.NomeDisciplina)
                .NotNull().NotEmpty();
        }
       
    }
}
