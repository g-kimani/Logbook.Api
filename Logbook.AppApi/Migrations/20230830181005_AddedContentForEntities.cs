using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logbook.AppApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedContentForEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Projects",
                newName: "Contnet");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contnet",
                table: "Projects",
                newName: "Description");
        }
    }
}
