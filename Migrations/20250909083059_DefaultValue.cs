using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Framework.Migrations
{
    /// <inheritdoc />
    public partial class DefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fullName = table.Column<string>(type: "nvarchar(max)", nullable: false, computedColumnSql: "[customerTitle] + ' ' + [customerName]"),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 1m),
                    total = table.Column<string>(type: "nvarchar(max)", nullable: false, computedColumnSql: "[price] + ' ' + [quantity]"),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");
        }
    }
}
