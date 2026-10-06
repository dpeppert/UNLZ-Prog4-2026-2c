using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventos.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreoTablaAsistente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asistentes",
                columns: table => new
                {
                    IdAsistente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdEvento = table.Column<int>(type: "int", nullable: false),
                    EventoIdEvento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistentes", x => x.IdAsistente);
                    table.ForeignKey(
                        name: "FK_Asistentes_Eventos_EventoIdEvento",
                        column: x => x.EventoIdEvento,
                        principalTable: "Eventos",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asistentes_EventoIdEvento",
                table: "Asistentes",
                column: "EventoIdEvento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asistentes");
        }
    }
}
