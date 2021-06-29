using System;

// TABELA USADA POR TODAS AS ENTIDADES, PARA TER ID, INCLUSAO E ALTERACAO

namespace HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES
{
    abstract public class TABELA_ENTIDADE
    {
        public int ID { get; internal set; }
        public DateTime Inclusao { get; set; }
        public DateTime Alteracao { get; set; }
    }
}
