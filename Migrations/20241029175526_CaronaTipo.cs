using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaLearnGo.Migrations
{
    /// <inheritdoc />
    public partial class CaronaTipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carona_CaronaTipo_CaronaTipoId",
                table: "Carona");

            migrationBuilder.DropTable(
                name: "CaronaTipo");

            migrationBuilder.DropIndex(
                name: "IX_Carona_CaronaTipoId",
                table: "Carona");

            migrationBuilder.DropColumn(
                name: "CaronaTipoId",
                table: "Carona");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CaronaTipoId",
                table: "Carona",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Carona_CaronaTipoId",
                table: "Carona",
                column: "CaronaTipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carona_CaronaTipo_CaronaTipoId",
                table: "Carona",
                column: "CaronaTipoId",
                principalTable: "CaronaTipo",
                principalColumn: "CaronaTipoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
