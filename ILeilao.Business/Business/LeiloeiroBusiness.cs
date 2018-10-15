using ILeilao.Domain;
using ILeilao.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ILeilao.Business
{
    public class LeiloeiroBusiness : ILeiloeiroBusiness
    {
        private readonly ILeiloeiroRepository _leiloeiroRepository;
        private readonly IContaRepository _contaRepository;

        public LeiloeiroBusiness(ILeiloeiroRepository leiloeiroRepository,
                                 IContaRepository contaRepository)
        {
            _leiloeiroRepository = leiloeiroRepository;
            _contaRepository = contaRepository;
        }

        public async Task RegistrarLeiloeiro(Leiloeiro leiloeiro)
        {
            await ChecaContaExistente(leiloeiro);
            await _contaRepository.AddAsync(leiloeiro.Conta);
            await _leiloeiroRepository.AddAsync(leiloeiro);
        }

        private async Task ChecaContaExistente(Leiloeiro leiloeiro)
        {
            var conta = await _contaRepository.FindAsync(c => c.Email == leiloeiro.Conta.Email);

            if (conta != null)
            {
                throw new Exception("Conta já cadastrada!");
            }
        }
    }
}
