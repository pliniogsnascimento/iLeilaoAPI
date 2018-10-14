using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ILeilao.Domain;
using ILeilao.Repository;

namespace ILeilao.Business
{
    public class LoginBusiness : ILoginBusiness
    {
        private readonly IContaRepository _contaRepository;
        private readonly IParticipanteRepository _participanteRepository;
        private readonly ILeiloeiroRepository _leiloeiroRepository;

        public LoginBusiness(IContaRepository contaRepository,
                             IParticipanteRepository participanteRepository,
                             ILeiloeiroRepository leiloeiroRepository)
        {
            _contaRepository = contaRepository;
            _participanteRepository = participanteRepository;
            _leiloeiroRepository = leiloeiroRepository;
        }

        public async Task<dynamic> EfetuarLogin(Conta conta)
        {
            var contaEncontrada = await _contaRepository.FindAsync(c => c.Email == conta.Email && c.Senha == conta.Senha);

            ChecarExistenciaConta(contaEncontrada);

            var participante = await BuscarContaParticipante(contaEncontrada);

            if (participante != null)
                return participante;

            return await BuscarContaLeiloeiro(contaEncontrada);
        }

        private void ChecarExistenciaConta(Conta conta)
        {
            if (conta == null)
                throw new Exception("Usuário ou senha incorretos!");
        }

        private async Task<Participante> BuscarContaParticipante(Conta conta)
        {
            return await _participanteRepository.FindAsync(c => c.Conta.Id == conta.Id);
        }

        private async Task<Leiloeiro> BuscarContaLeiloeiro(Conta conta)
        {
            return await _leiloeiroRepository.FindAsync(c => c.Conta.Id == conta.Id);
        }
    }
}
