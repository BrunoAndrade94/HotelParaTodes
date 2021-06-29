using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HotelParaTodes.Migrations
{
    public partial class p0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DB_CARGOS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: true)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alteracao = table.Column<DateTime>(nullable: true),
                    CargaHoraria = table.Column<float>(nullable: true),
                    Inclusao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Salario = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_CARGOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DB_ENDERECOS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: true)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alteracao = table.Column<DateTime>(nullable: true),
                    Inclusao = table.Column<DateTime>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    bairro = table.Column<string>(nullable: true),
                    cep = table.Column<string>(nullable: true),
                    complemento = table.Column<string>(nullable: true),
                    ddd = table.Column<string>(nullable: true),
                    gia = table.Column<string>(nullable: true),
                    ibge = table.Column<string>(nullable: true),
                    localidade = table.Column<string>(nullable: true),
                    logradouro = table.Column<string>(nullable: true),
                    siafi = table.Column<string>(nullable: true),
                    uf = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_ENDERECOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DB_LOGINS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: true)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_LOGINS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DB_QUARTOS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: true)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alteracao = table.Column<DateTime>(nullable: true),
                    Andar = table.Column<int>(nullable: true),
                    Avaliacao = table.Column<int>(nullable: true),
                    Inclusao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    ValorPorHora = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_QUARTOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DB_COLABORADORES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: true)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Admissao = table.Column<DateTime>(nullable: true),
                    Alteracao = table.Column<DateTime>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    CargoID = table.Column<int>(nullable: true),
                    Demissao = table.Column<DateTime>(nullable: true),
                    EMail = table.Column<string>(nullable: true),
                    EnderecoID = table.Column<int>(nullable: true),
                    Inclusao = table.Column<DateTime>(nullable: true),
                    LoginID = table.Column<int>(nullable: true),
                    Nascimento = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    RG = table.Column<string>(nullable: true),
                    Sexo = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_COLABORADORES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DB_COLABORADORES_DB_CARGOS_CargoID",
                        column: x => x.CargoID,
                        principalTable: "DB_CARGOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DB_COLABORADORES_DB_ENDERECOS_EnderecoID",
                        column: x => x.EnderecoID,
                        principalTable: "DB_ENDERECOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DB_COLABORADORES_DB_LOGINS_LoginID",
                        column: x => x.LoginID,
                        principalTable: "DB_LOGINS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DB_HOSPEDES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: true)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alteracao = table.Column<DateTime>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    EMail = table.Column<string>(nullable: true),
                    EnderecoID = table.Column<int>(nullable: true),
                    Inclusao = table.Column<DateTime>(nullable: true),
                    Nascimento = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    QuartoID = table.Column<int>(nullable: true),
                    RG = table.Column<string>(nullable: true),
                    Sexo = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_HOSPEDES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DB_HOSPEDES_DB_ENDERECOS_EnderecoID",
                        column: x => x.EnderecoID,
                        principalTable: "DB_ENDERECOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DB_HOSPEDES_DB_QUARTOS_QuartoID",
                        column: x => x.QuartoID,
                        principalTable: "DB_QUARTOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DB_PAGAMENTOS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: true)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alteracao = table.Column<DateTime>(nullable: true),
                    HOSPEDEID = table.Column<int>(nullable: true),
                    Inclusao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Operadora = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_PAGAMENTOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DB_PAGAMENTOS_DB_HOSPEDES_HOSPEDEID",
                        column: x => x.HOSPEDEID,
                        principalTable: "DB_HOSPEDES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DB_PAGAMENTOS_HOSPEDEID",
                table: "DB_PAGAMENTOS",
                column: "HOSPEDEID");

            migrationBuilder.CreateIndex(
                name: "IX_DB_COLABORADORES_CargoID",
                table: "DB_COLABORADORES",
                column: "CargoID");

            migrationBuilder.CreateIndex(
                name: "IX_DB_COLABORADORES_EnderecoID",
                table: "DB_COLABORADORES",
                column: "EnderecoID");

            migrationBuilder.CreateIndex(
                name: "IX_DB_COLABORADORES_LoginID",
                table: "DB_COLABORADORES",
                column: "LoginID");

            migrationBuilder.CreateIndex(
                name: "IX_DB_HOSPEDES_EnderecoID",
                table: "DB_HOSPEDES",
                column: "EnderecoID");

            migrationBuilder.CreateIndex(
                name: "IX_DB_HOSPEDES_QuartoID",
                table: "DB_HOSPEDES",
                column: "QuartoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DB_PAGAMENTOS");

            migrationBuilder.DropTable(
                name: "DB_COLABORADORES");

            migrationBuilder.DropTable(
                name: "DB_HOSPEDES");

            migrationBuilder.DropTable(
                name: "DB_CARGOS");

            migrationBuilder.DropTable(
                name: "DB_LOGINS");

            migrationBuilder.DropTable(
                name: "DB_ENDERECOS");

            migrationBuilder.DropTable(
                name: "DB_QUARTOS");
        }
    }
}
