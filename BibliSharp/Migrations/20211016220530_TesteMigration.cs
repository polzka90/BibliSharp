using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliSharp.Migrations
{
    public partial class TesteMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: true),
                    Sala = table.Column<string>(type: "TEXT", nullable: true),
                    Periodo = table.Column<string>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataCreacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CriadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AlteradoPor = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emprestismos",
                columns: table => new
                {
                    EmprestismoId = table.Column<int>(type: "INTEGER", nullable: false)
                                        .Annotation("Sqlite:Autoincrement", true),
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    LivroId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataRetirada = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CriadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    DataLimite = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AlteradoPor = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestismos", x => x.EmprestismoId);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Editora = table.Column<string>(type: "TEXT", nullable: true),
                    Autora = table.Column<string>(type: "TEXT", nullable: true),
                    Ano = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeUsuario = table.Column<string>(type: "TEXT", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: true),
                    Senha = table.Column<string>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataCreacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CriadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AlteradoPor = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Emprestismos");

            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
