using System;

namespace ILeilao.Domain
{
    public class Participante
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Conta Conta { get; set; }
    }
}
