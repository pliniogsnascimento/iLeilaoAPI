using System;

namespace ILeilao.Domain
{
    public class Produto
    {
        public string Descricao { get; set; }
        public decimal LanceMinimo { get; set; }
        public Vendedor Vendedor { get; set; }
        public IEnumerable<Lance> Lances { get; set; }
    }
}
