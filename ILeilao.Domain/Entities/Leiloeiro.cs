using System;
using System.Collections.Generic;

namespace ILeilao.Domain
{
    public class Leiloeiro
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Produto> ProdutosLeiloados { get; set; }
        public Conta Conta { get; set; }
    }
}
