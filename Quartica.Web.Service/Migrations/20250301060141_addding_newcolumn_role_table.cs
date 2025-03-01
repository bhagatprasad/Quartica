using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quartica.Web.Service.Migrations
{
    /// <inheritdoc />
    public partial class adddingnewcolumnroletable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "roles",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "roles");
        }
    }
}
