using System;

namespace ILeilao.Domain
{
    public class Lance
    {
        public decimal Valor { get; set; }
        public Participante Participante { get; set; }
    }
}
