using ILeilao.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ILeilao.Business
{
    public interface IParticipanteBusiness
    {
        Task RegistrarParticipante(Participante participante);
    }
}
