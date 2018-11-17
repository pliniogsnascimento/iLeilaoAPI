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
        public List<Lance> Lances { get; set; }
        public List<Participante> Participantes { get; set; }
        public string SenhaEncerramento { get; set; }

        public Produto()
        {
            Lances = new List<Lance>();
            Participantes = new List<Participante>();
        }
    }
}
