using System;
using System.Collections.Generic;

namespace ILeilao.Domain
{
    public class Leilao
    {
        public IEnumerable<Produto> Produtos { get; set; }
        public IEnumerable<Participante> Participantes { get; set; }
        public bool Status { get; set; }
        public Lance MaiorLance { get; set; }
    }
}
