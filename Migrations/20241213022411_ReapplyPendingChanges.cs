using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRestApi.Migrations
{
    /// <inheritdoc />
    public partial class ReapplyPendingChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_prepods",
                table: "prepods");

            migrationBuilder.RenameTable(
                name: "prepods",
                newName: "Prepods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prepods",
                table: "Prepods",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Prepods",
                table: "Prepods");

            migrationBuilder.RenameTable(
                name: "Prepods",
                newName: "prepods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_prepods",
                table: "prepods",
                column: "Id");
        }
    }
}
