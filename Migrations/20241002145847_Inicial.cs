using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaLearnGo.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaronaTipo",
                columns: table => new
                {
                    CaronaTipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaronaTipoDescricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaronaTipo", x => x.CaronaTipoId);
                });

            migrationBuilder.CreateTable(
                name: "Faculdade",
                columns: table => new
                {
                    FaculdadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaculdadeNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaculdadeCidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculdade", x => x.FaculdadeId);
                });

            migrationBuilder.CreateTable(
                name: "Cadastro",
                columns: table => new
                {
                    CadastroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CadastroNomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CadastroDataNascimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CadastroRm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CadastroCurso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CadastroEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CadastroSenha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CadastroEndereço = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaculdadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastro", x => x.CadastroId);
                    table.ForeignKey(
                        name: "FK_Cadastro_Faculdade_FaculdadeId",
                        column: x => x.FaculdadeId,
                        principalTable: "Faculdade",
                        principalColumn: "FaculdadeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carona",
                columns: table => new
                {
                    CaronaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaronaHorario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CaronaVeiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaronaVagas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaronaOrigem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaronaDestino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CadastroId = table.Column<int>(type: "int", nullable: false),
                    CaronaTipoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carona", x => x.CaronaId);
                    table.ForeignKey(
                        name: "FK_Carona_Cadastro_CadastroId",
                        column: x => x.CadastroId,
                        principalTable: "Cadastro",
                        principalColumn: "CadastroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carona_CaronaTipo_CaronaTipoId",
                        column: x => x.CaronaTipoId,
                        principalTable: "CaronaTipo",
                        principalColumn: "CaronaTipoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    AvaliacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CadastroId = table.Column<int>(type: "int", nullable: false),
                    CaronaId = table.Column<int>(type: "int", nullable: false),
                    AvaliacaoComentario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.AvaliacaoId);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Cadastro_CadastroId",
                        column: x => x.CadastroId,
                        principalTable: "Cadastro",
                        principalColumn: "CadastroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Carona_CaronaId",
                        column: x => x.CaronaId,
                        principalTable: "Carona",
                        principalColumn: "CaronaId");
                });

            migrationBuilder.CreateTable(
                name: "CaronaHasCadastro",
                columns: table => new
                {
                    CaronaHasCadastroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CadastroId = table.Column<int>(type: "int", nullable: false),
                    CaronaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaronaHasCadastro", x => x.CaronaHasCadastroId);
                    table.ForeignKey(
                        name: "FK_CaronaHasCadastro_Cadastro_CadastroId",
                        column: x => x.CadastroId,
                        principalTable: "Cadastro",
                        principalColumn: "CadastroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaronaHasCadastro_Carona_CaronaId",
                        column: x => x.CaronaId,
                        principalTable: "Carona",
                        principalColumn: "CaronaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_CadastroId",
                table: "Avaliacao",
                column: "CadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_CaronaId",
                table: "Avaliacao",
                column: "CaronaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cadastro_FaculdadeId",
                table: "Cadastro",
                column: "FaculdadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Carona_CadastroId",
                table: "Carona",
                column: "CadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Carona_CaronaTipoId",
                table: "Carona",
                column: "CaronaTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_CaronaHasCadastro_CadastroId",
                table: "CaronaHasCadastro",
                column: "CadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_CaronaHasCadastro_CaronaId",
                table: "CaronaHasCadastro",
                column: "CaronaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "CaronaHasCadastro");

            migrationBuilder.DropTable(
                name: "Carona");

            migrationBuilder.DropTable(
                name: "Cadastro");

            migrationBuilder.DropTable(
                name: "CaronaTipo");

            migrationBuilder.DropTable(
                name: "Faculdade");
        }
    }
}
