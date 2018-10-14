using ILeilao.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILeilao.Repository
{
    public class ContaRepository : BaseRepository<Conta>, IContaRepository
    {
        public ContaRepository(ILeilaoContext context)
            : base(context, "Conta")
        {
        }
    }
}
