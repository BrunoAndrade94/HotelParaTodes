using HotelParaTodes.NOTIFICACOES;
using HotelParaTodes.REGRAS_DE_NEGOCIO.INTERFACE;
using HotelParaTodes.REGRAS_DE_NEGOCIO.UTILITARIOS;
using HPT_DLL.Entidades.Pessoas;
using System.Collections.Generic;
using System.Linq;

namespace HPT_DLL.BancoDeDados.DAO
{
    class HOSPEDE_DAO : ICONTEXTO
    {
        #region IMPLEMENTACAO MANUAL
        private CONTEXTO contexto = new CONTEXTO();
        private static VERIFICAR verificar = new VERIFICAR();

        public void Dispose()
        {
            contexto.Dispose();
        }
        public List<HOSPEDE> Trazer()
        {
            return contexto.DB_HOSPEDES.ToList();
        }
        #endregion
        #region IMPLEMENTADO COM A INTERFACE
        public void Adicionar(dynamic h)
        {
            contexto.DB_HOSPEDES.Add(h);
            contexto.SaveChanges();
        }
        public void Atualizar(dynamic h)
        {
            contexto.DB_HOSPEDES.Update(h);
            contexto.DB_ENDERECOS.Update(h.Endereco);
            contexto.SaveChanges();
        }
        public void Remover(dynamic h)
        {
            contexto.DB_HOSPEDES.Remove(h);
            contexto.SaveChanges();
        }
        #endregion
    }
}
