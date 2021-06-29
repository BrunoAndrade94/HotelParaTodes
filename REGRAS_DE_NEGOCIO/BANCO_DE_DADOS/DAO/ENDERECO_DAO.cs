using HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES.ENDERECOS;
using HotelParaTodes.REGRAS_DE_NEGOCIO.INTERFACE;
using HPT_DLL.BancoDeDados;
using System.Collections.Generic;
using System.Linq;

namespace HotelParaTodes.REGRAS_DE_NEGOCIO.BANCO_DE_DADOS.DAO
{
    class ENDERECO_DAO : ICONTEXTO
    {
        private CONTEXTO contexto = new CONTEXTO();

        public void Adicionar(dynamic h)
        {
            contexto.DB_ENDERECOS.Add(h);
            contexto.SaveChanges();
        }

        public void Atualizar(dynamic h)
        {
            contexto.DB_ENDERECOS.Update(h);
            contexto.SaveChanges();
        }

        public void Remover(dynamic h)
        {
            contexto.DB_ENDERECOS.Remove(h);
            contexto.SaveChanges();
        }

        public List<ENDERECO> Trazer()
        {
            return contexto.DB_ENDERECOS.ToList();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
