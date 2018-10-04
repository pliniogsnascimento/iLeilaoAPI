using System;

namespace ILeilao.Domain
{
    public class Vendedor
    {
        public IEnumerable<Produto> ProdutosLeiloados { get; set; }
        public Conta Conta { get; set; }
    }
}
