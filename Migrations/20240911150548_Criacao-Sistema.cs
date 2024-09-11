using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaLearnGo.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoSistema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Login",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginSenha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.LoginId);
                });

            migrationBuilder.CreateTable(
                name: "OfertarCarona",
                columns: table => new
                {
                    OfertarCaronaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfertarCaronaPeriodo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfertarCaronaHorário = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OfertarCaronaEndereço = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfertarCaronaVagas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfertarCaronaVeiculo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertarCarona", x => x.OfertarCaronaId);
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
                name: "SolicitarCarona",
                columns: table => new
                {
                    SolicitarCaronaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitarCaronaNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SolicitarCaronaHorário = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SolicitarCaronaEndereço = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaculdadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitarCarona", x => x.SolicitarCaronaId);
                    table.ForeignKey(
                        name: "FK_SolicitarCarona_Faculdade_FaculdadeId",
                        column: x => x.FaculdadeId,
                        principalTable: "Faculdade",
                        principalColumn: "FaculdadeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    AvaliacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvaliacaoQuemAvaliou = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvaliacaoAvaliado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvaliacaoComentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CadastroId = table.Column<int>(type: "int", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    PerfilId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerfilFoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CadastroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.PerfilId);
                    table.ForeignKey(
                        name: "FK_Perfil_Cadastro_CadastroId",
                        column: x => x.CadastroId,
                        principalTable: "Cadastro",
                        principalColumn: "CadastroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_CadastroId",
                table: "Avaliacao",
                column: "CadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Cadastro_FaculdadeId",
                table: "Cadastro",
                column: "FaculdadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Perfil_CadastroId",
                table: "Perfil",
                column: "CadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitarCarona_FaculdadeId",
                table: "SolicitarCarona",
                column: "FaculdadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "OfertarCarona");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropTable(
                name: "SolicitarCarona");

            migrationBuilder.DropTable(
                name: "Cadastro");

            migrationBuilder.DropTable(
                name: "Faculdade");
        }
    }
}
