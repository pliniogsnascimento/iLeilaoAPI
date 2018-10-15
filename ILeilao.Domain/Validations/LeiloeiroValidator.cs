using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILeilao.Domain
{
    public class LeiloeiroValidator : AbstractValidator<Leiloeiro>
    {
        public LeiloeiroValidator()
        {
            RuleFor(x => x.Nome).NotEmpty();
            RuleFor(x => x.Conta).NotNull();
            RuleFor(x => x.Conta.Email).NotNull();
            RuleFor(x => x.Conta.Email).EmailAddress();
            RuleFor(x => x.Conta.Senha).Length(6, 60);
        }
    }
}
