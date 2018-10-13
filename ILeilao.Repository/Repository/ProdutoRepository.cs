using ILeilao.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILeilao.Repository
{
    public sealed class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ILeilaoContext context)
            : base(context, "Produto")
        {
        }
    }
}
