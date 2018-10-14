using ILeilao.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILeilao.Repository
{
    public class LeiloeiroRepository : BaseRepository<Leiloeiro>, ILeiloeiroRepository
    {
        public LeiloeiroRepository(ILeilaoContext context)
            : base(context, "Leiloeiro")
        {
        }
    }
}
