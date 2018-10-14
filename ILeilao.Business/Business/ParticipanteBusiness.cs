using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ILeilao.Domain;
using ILeilao.Repository;

namespace ILeilao.Business
{
    public class ParticipanteBusiness : IParticipanteBusiness
    {
        private readonly IParticipanteRepository _participanteRepository;
        private readonly IContaRepository _contaRepository;

        public ParticipanteBusiness(IParticipanteRepository participanteRepository, 
                                    IContaRepository contaRepository)
        {
            _participanteRepository = participanteRepository;
            _contaRepository = contaRepository;
        }

        public async Task RegistrarParticipante(Participante participante)
        {
            await ChecaContaExistente(participante);
            await _contaRepository.AddAsync(participante.Conta);
            await _participanteRepository.AddAsync(participante);
        }

        private async Task ChecaContaExistente(Participante participante)
        {
            var conta = await _contaRepository.FindAsync(c => c.Email == participante.Conta.Email);

            if(conta != null)
            {
                throw new Exception("Conta já cadastrada!");
            }
        }
    }
}
