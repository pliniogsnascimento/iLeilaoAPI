using ILeilao.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ILeilao.Service
{
    public interface ILeiloeiroService
    {
        Task RegistrarLeiloeiro(Leiloeiro leiloeiro);
    }
}
