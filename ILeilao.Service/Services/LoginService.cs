using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ILeilao.Business;
using ILeilao.Domain;

namespace ILeilao.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginBusiness _business;

        public LoginService(ILoginBusiness business)
        {
            _business = business;
        }

        public async Task<dynamic> EfetuarLogin(Conta conta)
        {
            return await _business.EfetuarLogin(conta);
        }
    }
}
