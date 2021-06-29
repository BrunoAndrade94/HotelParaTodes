using HotelParaTodes.REGRAS_DE_NEGOCIO.INTERFACE;
using HPT_DLL.BancoDeDados;
using HPT_DLL.Entidades.Pessoas;
using System.Collections.Generic;
using System.Linq;

namespace HotelParaTodes.REGRAS_DE_NEGOCIO.BANCO_DE_DADOS.DAO
{
    class COLABORADOR_DAO : ICONTEXTO
    {
        private CONTEXTO contexto = new CONTEXTO();

        public void Adicionar(dynamic h)
        {
            contexto.DB_COLABORADORES.Add(h);
            //contexto.DB_ENDERECOS.Update(h.Endereco);
            contexto.DB_CARGOS.Update(h.Cargo);
            contexto.SaveChanges();
        }
        public void Atualizar(dynamic h)
        {
            contexto.DB_COLABORADORES.Update(h);
            //contexto.DB_COLABORADORES.Update(h.Endereco);
            //contexto.DB_COLABORADORES.Update(h.Cargo);
            //contexto.DB_COLABORADORES.Update(h.Login);
            contexto.SaveChanges();
        }
        public void Remover(dynamic h)
        {
            contexto.DB_COLABORADORES.Remove(h);
            contexto.SaveChanges();
        }
        public List<COLABORADOR> Trazer()
        {
            return contexto.DB_COLABORADORES.ToList();
        }
        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
