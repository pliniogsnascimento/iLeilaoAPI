using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILeilao.Domain
{
    public class ParticipanteValidator : AbstractValidator<Participante>
    {
        public ParticipanteValidator()
        {
            RuleFor(x => x.Nome).NotNull();
            RuleFor(x => x.Telefone).NotNull();
            RuleFor(x => x.Conta).NotEmpty();
            RuleFor(x => x.Conta.Email).EmailAddress();
            RuleFor(x => x.Conta.Senha).Length(6, 60);
        }
    }
}
