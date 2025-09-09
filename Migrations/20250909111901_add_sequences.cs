using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Framework.Migrations
{
    /// <inheritdoc />
    public partial class add_sequences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_Name",
                table: "Students");

            migrationBuilder.CreateSequence<int>(
                name: "DeiveryOrder",
                startValue: 103L);

            migrationBuilder.AddColumn<int>(
                name: "DeiveryOrder",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValueSql: "Next Value For DeiveryOrder");

            migrationBuilder.CreateTable(
                name: "Uniforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeiveryOrder = table.Column<int>(type: "int", nullable: false, defaultValueSql: "Next Value For DeiveryOrder")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uniforms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_Name",
                table: "Students",
                column: "Name",
                unique: true,
                filter: "Name is not null");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uniforms");

            migrationBuilder.DropIndex(
                name: "IX_Students_Name",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DeiveryOrder",
                table: "Books");

            migrationBuilder.DropSequence(
                name: "DeiveryOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Name",
                table: "Students",
                column: "Name",
                unique: true);
        }
    }
}
