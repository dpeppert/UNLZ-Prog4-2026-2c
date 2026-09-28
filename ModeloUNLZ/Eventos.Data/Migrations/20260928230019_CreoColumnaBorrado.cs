using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventos.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreoColumnaBorrado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Borrado",
                table: "Eventos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Borrado",
                table: "Eventos");
        }
    }
}
