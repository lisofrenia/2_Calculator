using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DataInputVarians",
                columns: table => new
                {
                    ID_DataInputVarian = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Num1 = table.Column<string>(type: "varchar(128)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Num2 = table.Column<string>(type: "varchar(128)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Operation = table.Column<string>(type: "varchar(128)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Result = table.Column<string>(type: "varchar(128)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataInputVarians", x => x.ID_DataInputVarian);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataInputVarians");
        }
    }
}
