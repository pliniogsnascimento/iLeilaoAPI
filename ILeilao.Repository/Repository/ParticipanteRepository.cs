using ILeilao.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ILeilao.Repository
{
    public class ParticipanteRepository : BaseRepository<Participante>, IParticipanteRepository
    {
        public ParticipanteRepository(ILeilaoContext context)
            : base(context, "Participante")
        {
        }
    }
}
