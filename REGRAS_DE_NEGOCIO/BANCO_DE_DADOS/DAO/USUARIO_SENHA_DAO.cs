using HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES;
using HotelParaTodes.REGRAS_DE_NEGOCIO.INTERFACE;
using HPT_DLL.BancoDeDados;
using System.Collections.Generic;
using System.Linq;

namespace HotelParaTodes.REGRAS_DE_NEGOCIO.BANCO_DE_DADOS.DAO
{
    class USUARIO_SENHA_DAO : ICONTEXTO
    {
        private CONTEXTO contexto = new CONTEXTO();

        public void Adicionar(dynamic h)
        {
            contexto.DB_LOGINS.Add(h);
            contexto.SaveChanges();
        }
        public void Atualizar(dynamic h)
        {
            contexto.DB_LOGINS.Update(h);
            contexto.SaveChanges();
        }
        public void Remover(dynamic h)
        {
            contexto.DB_LOGINS.Remove(h);
            contexto.SaveChanges();
        }
        public List<USUARIO_SENHA> Trazer()
        {
            return contexto.DB_LOGINS.ToList();
        }
        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
