using System;

namespace ILeilao.Domain
{
    public class Participante
    {
        public string Email { get; set; }
        public Conta Conta { get; set; }
    }
}
