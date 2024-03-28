using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quartica.Web.Service.Migrations
{
    /// <inheritdoc />
    public partial class ProductTableAddingNEW : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "productAuditLogs",
                columns: table => new
                {
                    ProductAuditLogId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<long>(type: "INTEGER", nullable: true),
                    UserId = table.Column<long>(type: "INTEGER", nullable: true),
                    ActivityId = table.Column<long>(type: "INTEGER", nullable: true),
                    ValueBefore = table.Column<string>(type: "TEXT", nullable: false),
                    ValueAfter = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<long>(type: "INTEGER", nullable: true),
                    ModifiedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<long>(type: "INTEGER", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productAuditLogs", x => x.ProductAuditLogId);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    SalePrice = table.Column<decimal>(type: "TEXT", nullable: true),
                    RegularPrice = table.Column<decimal>(type: "TEXT", nullable: true),
                    OfferPrice = table.Column<decimal>(type: "TEXT", nullable: true),
                    Avilabulity = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<long>(type: "INTEGER", nullable: true),
                    ModifiedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    ModifiedBy = table.Column<long>(type: "INTEGER", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productAuditLogs");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
