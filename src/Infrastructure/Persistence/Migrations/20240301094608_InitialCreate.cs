using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dummy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dummy", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Dummy",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6d492016-8364-430c-8cd2-979a00990f0b"), "6d4920168364430c8cd2979a00990f0b" },
                    { new Guid("b380079b-2e50-45ad-976a-1639add85b52"), "b380079b2e5045ad976a1639add85b52" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dummy");
        }
    }
}
