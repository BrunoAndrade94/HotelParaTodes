using HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES;
using HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES.ENDERECOS;
using HPT_DLL.Entidades;
using HPT_DLL.Entidades.Pessoas;
using Microsoft.EntityFrameworkCore;

namespace HPT_DLL.BancoDeDados
{
    public class CONTEXTO : DbContext
    {
        #region TABELAS DO BANCO
        public DbSet<HOSPEDE> DB_HOSPEDES { get; set; }
        public DbSet<COLABORADOR> DB_COLABORADORES { get; set; }
        public DbSet<QUARTO> DB_QUARTOS { get; set; }
        public DbSet<ENDERECO> DB_ENDERECOS { get; set; }
        public DbSet<CARGO> DB_CARGOS { get; set; }
        public DbSet<PAGAMENTO> DB_PAGAMENTOS { get; set; }
        public DbSet<USUARIO_SENHA> DB_LOGINS { get; set; }
        #endregion

        #region STRING DE ACESSO AO BANCO
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server=PC\MACONHA;Database=HOTEL_PARA_TODES;User Id=sa;Password=1234;");
        }
        #endregion
    }
}
