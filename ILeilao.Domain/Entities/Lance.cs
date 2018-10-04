using System;

namespace ILeilao.Domain
{
    public class Lance
    {
        public decimal Valor { get; set; }
        public Participante Participante { get; set; }
        public Produto Produto { get; set; }
        public bool Status { get; set; }
    }
}
