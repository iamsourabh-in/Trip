using Microsoft.EntityFrameworkCore.Migrations;

namespace Trip.Creator.Api.Migrations.CreatorReaderDb
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MediumPath",
                table: "CreationResource",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmallPath",
                table: "CreationResource",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MediumPath",
                table: "CreationResource");

            migrationBuilder.DropColumn(
                name: "SmallPath",
                table: "CreationResource");
        }
    }
}
