using HotelParaTodes.REGRAS_DE_NEGOCIO.INTERFACE;
using HPT_DLL.BancoDeDados;
using HPT_DLL.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace HotelParaTodes.REGRAS_DE_NEGOCIO.BANCO_DE_DADOS.DAO
{
    class QUARTO_DAO : ICONTEXTO
    {
        private CONTEXTO contexto = new CONTEXTO();
        public void Dispose()
        {
            contexto.Dispose();
        }
        public List<QUARTO> Trazer()
        {
            return contexto.DB_QUARTOS.ToList();
        }
        public void Adicionar(dynamic h)
        {
            contexto.DB_QUARTOS.Add(h);
            contexto.SaveChanges();
        }
        public void Atualizar(dynamic h)
        {
            contexto.DB_QUARTOS.Update(h);
            contexto.SaveChanges();
        }
        public void Remover(dynamic h)
        {
            contexto.DB_QUARTOS.Remove(h);
            contexto.SaveChanges();
        }
    }
}
