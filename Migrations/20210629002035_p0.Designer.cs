using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HPT_DLL.BancoDeDados;

namespace HotelParaTodes.Migrations
{
    [DbContext(typeof(CONTEXTO))]
    [Migration("20210629002035_p0")]
    partial class p0
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES.CARGO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Alteracao");

                    b.Property<float>("CargaHoraria");

                    b.Property<DateTime>("Inclusao");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<float>("Salario");

                    b.HasKey("ID");

                    b.ToTable("DB_CARGOS");
                });

            modelBuilder.Entity("HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES.ENDERECOS.ENDERECO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Alteracao");

                    b.Property<DateTime>("Inclusao");

                    b.Property<string>("Numero");

                    b.Property<string>("bairro")
                        .IsRequired();

                    b.Property<string>("cep")
                        .IsRequired();

                    b.Property<string>("complemento");

                    b.Property<string>("ddd");

                    b.Property<string>("gia");

                    b.Property<string>("ibge");

                    b.Property<string>("localidade");

                    b.Property<string>("logradouro")
                        .IsRequired();

                    b.Property<string>("siafi");

                    b.Property<string>("uf")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("DB_ENDERECOS");
                });

            modelBuilder.Entity("HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES.PAGAMENTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Alteracao");

                    b.Property<int?>("HOSPEDEID");

                    b.Property<DateTime>("Inclusao");

                    b.Property<string>("Nome");

                    b.Property<string>("Operadora");

                    b.HasKey("ID");

                    b.HasIndex("HOSPEDEID");

                    b.ToTable("DB_PAGAMENTOS");
                });

            modelBuilder.Entity("HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES.USUARIO_SENHA", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Login");

                    b.Property<string>("Senha");

                    b.HasKey("ID");

                    b.ToTable("DB_LOGINS");
                });

            modelBuilder.Entity("HPT_DLL.Entidades.Pessoas.COLABORADOR", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Admissao");

                    b.Property<DateTime>("Alteracao");

                    b.Property<string>("CPF")
                        .IsRequired();

                    b.Property<int>("CargoID");

                    b.Property<DateTime>("Demissao");

                    b.Property<string>("EMail")
                        .IsRequired();

                    b.Property<int>("EnderecoID");

                    b.Property<DateTime>("Inclusao");

                    b.Property<int>("LoginID");

                    b.Property<DateTime>("Nascimento");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("RG")
                        .IsRequired();

                    b.Property<string>("Sexo")
                        .IsRequired();

                    b.Property<string>("Sobrenome")
                        .IsRequired();

                    b.Property<string>("Telefone")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("CargoID");

                    b.HasIndex("EnderecoID");

                    b.HasIndex("LoginID");

                    b.ToTable("DB_COLABORADORES");
                });

            modelBuilder.Entity("HPT_DLL.Entidades.Pessoas.HOSPEDE", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Alteracao");

                    b.Property<string>("CPF")
                        .IsRequired();

                    b.Property<string>("EMail")
                        .IsRequired();

                    b.Property<int>("EnderecoID");

                    b.Property<DateTime>("Inclusao");

                    b.Property<DateTime>("Nascimento");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int?>("QuartoID");

                    b.Property<string>("RG")
                        .IsRequired();

                    b.Property<string>("Sexo")
                        .IsRequired();

                    b.Property<string>("Sobrenome")
                        .IsRequired();

                    b.Property<string>("Telefone")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("EnderecoID");

                    b.HasIndex("QuartoID");

                    b.ToTable("DB_HOSPEDES");
                });

            modelBuilder.Entity("HPT_DLL.Entidades.QUARTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Alteracao");

                    b.Property<int>("Andar");

                    b.Property<int>("Avaliacao");

                    b.Property<DateTime>("Inclusao");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("Numero");

                    b.Property<string>("Tipo")
                        .IsRequired();

                    b.Property<float>("ValorPorHora");

                    b.HasKey("ID");

                    b.ToTable("DB_QUARTOS");
                });

            modelBuilder.Entity("HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES.PAGAMENTO", b =>
                {
                    b.HasOne("HPT_DLL.Entidades.Pessoas.HOSPEDE")
                        .WithMany("FormaPagamento")
                        .HasForeignKey("HOSPEDEID");
                });

            modelBuilder.Entity("HPT_DLL.Entidades.Pessoas.COLABORADOR", b =>
                {
                    b.HasOne("HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES.CARGO", "Cargo")
                        .WithMany()
                        .HasForeignKey("CargoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES.ENDERECOS.ENDERECO", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES.USUARIO_SENHA", "Login")
                        .WithMany()
                        .HasForeignKey("LoginID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HPT_DLL.Entidades.Pessoas.HOSPEDE", b =>
                {
                    b.HasOne("HotelParaTodes.REGRAS_DE_NEGOCIO.ENTIDADES.ENDERECOS.ENDERECO", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HPT_DLL.Entidades.QUARTO", "Quarto")
                        .WithMany()
                        .HasForeignKey("QuartoID");
                });
        }
    }
}
