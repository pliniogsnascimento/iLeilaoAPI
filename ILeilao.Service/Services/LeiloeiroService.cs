using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ILeilao.Business;
using ILeilao.Domain;

namespace ILeilao.Service
{
    public class LeiloeiroService : ILeiloeiroService
    {
        private readonly ILeiloeiroBusiness _leiloeiroBusiness;

        public LeiloeiroService(ILeiloeiroBusiness leiloeiroBusiness)
        {
            _leiloeiroBusiness = leiloeiroBusiness;
        }

        public async Task RegistrarLeiloeiro(Leiloeiro leiloeiro)
        {
            await _leiloeiroBusiness.RegistrarLeiloeiro(leiloeiro);
        }
    }
}
