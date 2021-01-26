using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarPark.Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PessoaFisica",
                columns: table => new
                {
                    PessoaFisicaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(maxLength: 11, nullable: true),
                    Nome = table.Column<string>(maxLength: 60, nullable: true),
                    Sexo = table.Column<string>(fixedLength: true, maxLength: 2, nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Rg = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaFisica", x => x.PessoaFisicaId);
                });

            migrationBuilder.CreateTable(
                name: "PessoaJuridica",
                columns: table => new
                {
                    PessoaJuridicaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(maxLength: 11, nullable: true),
                    RazaoSocial = table.Column<string>(maxLength: 100, nullable: true),
                    NomeFantasia = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaJuridica", x => x.PessoaJuridicaId);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    EmailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnderecoEmail = table.Column<string>(maxLength: 160, nullable: true),
                    PessoaFisicaId = table.Column<int>(nullable: true),
                    PessoaJuridicaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.EmailId);
                    table.ForeignKey(
                        name: "FK_Email_PessoaFisica_PessoaFisicaId",
                        column: x => x.PessoaFisicaId,
                        principalTable: "PessoaFisica",
                        principalColumn: "PessoaFisicaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Email_PessoaJuridica_PessoaJuridicaId",
                        column: x => x.PessoaJuridicaId,
                        principalTable: "PessoaJuridica",
                        principalColumn: "PessoaJuridicaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(maxLength: 100, nullable: true),
                    Numero = table.Column<string>(maxLength: 5, nullable: true),
                    Complemento = table.Column<string>(maxLength: 10, nullable: true),
                    CEP = table.Column<string>(fixedLength: true, maxLength: 8, nullable: true),
                    Bairro = table.Column<string>(maxLength: 40, nullable: true),
                    Cidade = table.Column<string>(maxLength: 30, nullable: true),
                    Estado = table.Column<string>(fixedLength: true, maxLength: 2, nullable: true),
                    PessoaFisicaId = table.Column<int>(nullable: true),
                    PessoaJuridicaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.EnderecoId);
                    table.ForeignKey(
                        name: "FK_Endereco_PessoaFisica_PessoaFisicaId",
                        column: x => x.PessoaFisicaId,
                        principalTable: "PessoaFisica",
                        principalColumn: "PessoaFisicaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Endereco_PessoaJuridica_PessoaJuridicaId",
                        column: x => x.PessoaJuridicaId,
                        principalTable: "PessoaJuridica",
                        principalColumn: "PessoaJuridicaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    TelefoneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(maxLength: 11, nullable: true),
                    PessoaFisicaId = table.Column<int>(nullable: true),
                    PessoaJuridicaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.TelefoneId);
                    table.ForeignKey(
                        name: "FK_Telefone_PessoaFisica_PessoaFisicaId",
                        column: x => x.PessoaFisicaId,
                        principalTable: "PessoaFisica",
                        principalColumn: "PessoaFisicaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Telefone_PessoaJuridica_PessoaJuridicaId",
                        column: x => x.PessoaJuridicaId,
                        principalTable: "PessoaJuridica",
                        principalColumn: "PessoaJuridicaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Email_PessoaFisicaId",
                table: "Email",
                column: "PessoaFisicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Email_PessoaJuridicaId",
                table: "Email",
                column: "PessoaJuridicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_PessoaFisicaId",
                table: "Endereco",
                column: "PessoaFisicaId",
                unique: true,
                filter: "[PessoaFisicaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_PessoaJuridicaId",
                table: "Endereco",
                column: "PessoaJuridicaId",
                unique: true,
                filter: "[PessoaJuridicaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_PessoaFisicaId",
                table: "Telefone",
                column: "PessoaFisicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_PessoaJuridicaId",
                table: "Telefone",
                column: "PessoaJuridicaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "PessoaFisica");

            migrationBuilder.DropTable(
                name: "PessoaJuridica");
        }
    }
}
