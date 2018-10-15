using System;

namespace ILeilao.Domain
{
    public class Conta
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public AcessoConta AcessoConta { get; set; }
    }
}