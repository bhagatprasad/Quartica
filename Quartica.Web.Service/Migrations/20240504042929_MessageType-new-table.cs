using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quartica.Web.Service.Migrations
{
    /// <inheritdoc />
    public partial class MessageTypenewtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "messageTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<long>(type: "INTEGER", nullable: true),
                    ModifiedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<long>(type: "INTEGER", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messageTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productAuditLogs_ProductId",
                table: "productAuditLogs",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_productAuditLogs_products_ProductId",
                table: "productAuditLogs",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productAuditLogs_products_ProductId",
                table: "productAuditLogs");

            migrationBuilder.DropTable(
                name: "messageTypes");

            migrationBuilder.DropIndex(
                name: "IX_productAuditLogs_ProductId",
                table: "productAuditLogs");
        }
    }
}
