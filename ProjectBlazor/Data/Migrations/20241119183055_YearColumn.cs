using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectBlazor.Data.Migrations
{
    /// <inheritdoc />
    public partial class YearColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "Vehiculos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Vehiculos");
        }
    }
}
