using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILeilao.Domain.Validations
{
    public class LanceValidator : AbstractValidator<Lance>
    {
        public LanceValidator()
        {
            RuleFor(x => x.Valor).NotNull();
            RuleFor(x => x.Participante).NotNull();
            RuleFor(x => x.Participante.Id).NotNull();
        }
    }
}
