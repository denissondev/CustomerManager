using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaipherCustomerManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Name", "Password", "Role" },
                values: new object[] { new Guid("d3b4f5e6-7a8b-4c9d-8e1f-2a3b4c5d6e7f"), "admin@example.com", "Admin", "$2a$11$/sdS9UmL2aRP/WdIL5Pc1ehADLsMH00GCxOZG408BB25KJpp1t656", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
