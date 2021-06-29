using HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES;
using HotelParaTodes.REGRAS_DE_NEGOCIO.INTERFACE;
using HPT_DLL.BancoDeDados;
using System.Collections.Generic;
using System.Linq;

namespace HotelParaTodes.REGRAS_DE_NEGOCIO.BANCO_DE_DADOS.DAO
{
    class CARGO_DAO : ICONTEXTO
    {
        private CONTEXTO contexto = new CONTEXTO();

        public void Adicionar(dynamic h)
        {
            contexto.DB_CARGOS.Add(h);
            contexto.SaveChanges();
        }

        public void Atualizar(dynamic h)
        {
            contexto.DB_CARGOS.Update(h);
            contexto.SaveChanges();
        }

        public void Remover(dynamic h)
        {
            contexto.DB_CARGOS.Remove(h);
            contexto.SaveChanges();
        }

        public List<CARGO> Trazer()
        {
            return contexto.DB_CARGOS.ToList();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
