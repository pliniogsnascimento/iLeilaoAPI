using System;
using System.Collections.Generic;

namespace ILeilao.Domain
{
    public class Produto
    {
        public string Id { get; set; }
        public StatusProduto Status { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal LanceMinimo { get; set; }
        public Vendedor Vendedor { get; set; }
        public IEnumerable<Lance> Lances { get; set; }
        public IEnumerable<Participante> Participantes { get; set; }
        public string SenhaEncerramento { get; set; }
    }

}
