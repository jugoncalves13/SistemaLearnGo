using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaLearnGo.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoAvaliacao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvaliacaoComentario",
                table: "Avaliacao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PerfilId",
                table: "Avaliacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_PerfilId",
                table: "Avaliacao",
                column: "PerfilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_Perfil_PerfilId",
                table: "Avaliacao",
                column: "PerfilId",
                principalTable: "Perfil",
                principalColumn: "PerfilId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_Perfil_PerfilId",
                table: "Avaliacao");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacao_PerfilId",
                table: "Avaliacao");

            migrationBuilder.DropColumn(
                name: "AvaliacaoComentario",
                table: "Avaliacao");

            migrationBuilder.DropColumn(
                name: "PerfilId",
                table: "Avaliacao");
        }
    }
}
