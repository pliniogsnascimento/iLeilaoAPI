using ILeilao.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ILeilao.Service
{
    public interface ILoginService
    {
        Task<dynamic> EfetuarLogin(Conta conta);
    }
}
