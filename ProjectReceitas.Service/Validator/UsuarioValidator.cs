using FluentValidation;
using ProjectReceitas.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectReceitas.Service.Validator
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Não foi possível encontrar o objeto.");
                    });

            RuleFor(c => c.Login)
                .NotEmpty().WithMessage("Obrigatório informar o login.")
                .NotNull().WithMessage("Obrigatório informar o login.");
        }
    }
}

