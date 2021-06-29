using System;

namespace HotelParaTodes.REGRAS_DE_NEGOCIO.INTERFACE
{
    public interface ICONTEXTO : IDisposable
    {
        void Adicionar(dynamic h);
        void Atualizar(dynamic h);
        void Remover(dynamic h);
        //List<> Trazer();
    }
}
