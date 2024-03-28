using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quartica.Web.Service.Migrations
{
    /// <inheritdoc />
    public partial class ProductTableAdding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_userAuditLogs_UserId",
                table: "userAuditLogs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_userAuditLogs_users_UserId",
                table: "userAuditLogs",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userAuditLogs_users_UserId",
                table: "userAuditLogs");

            migrationBuilder.DropIndex(
                name: "IX_userAuditLogs_UserId",
                table: "userAuditLogs");
        }
    }
}
