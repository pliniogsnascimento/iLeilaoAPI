using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILeilao.Domain
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(x => x.Descricao).NotEmpty();
            RuleFor(x => x.LanceMinimo).NotNull();
            RuleFor(x => x.Vendedor).NotNull();
            RuleFor(x => x.SenhaEncerramento).NotEmpty();
        }
    }
}
