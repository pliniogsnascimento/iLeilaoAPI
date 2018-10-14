using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ILeilao.Business;
using ILeilao.Domain;

namespace ILeilao.Service
{
    public class ParticipanteService : IParticipanteService
    {
        private readonly IParticipanteBusiness _business;

        public ParticipanteService(IParticipanteBusiness business)
        {
            _business = business;
        }

        public async Task RegistrarParticipante(Participante participante)
        {
            await _business.RegistrarParticipante(participante);
        }
    }
}
