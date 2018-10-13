using System;
using System.Collections.Generic;

namespace ILeilao.Domain
{
    public class Leiloeiro
    {
        public IEnumerable<Produto> ProdutosLeiloados { get; set; }
        public Conta Conta { get; set; }
    }
}
