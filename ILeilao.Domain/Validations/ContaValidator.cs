using FluentValidation;
using ILeilao.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILeilao.Domain
{
    public class ContaValidator : AbstractValidator<Conta>
    {
        public ContaValidator()
        {
            RuleFor(x => x.Email).NotNull();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Senha).Length(6, 60);
        }
    }
}
