using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppDbContext.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "test");

            migrationBuilder.CreateSequence(
                name: "childrenitemseq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "parentseq",
                schema: "test",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "status",
                schema: "test",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "parents",
                schema: "test",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    statusid = table.Column<int>(name: "status_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parents", x => x.id);
                    table.ForeignKey(
                        name: "FK_parents_status_status_id",
                        column: x => x.statusid,
                        principalSchema: "test",
                        principalTable: "status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "children",
                schema: "test",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    parentid = table.Column<int>(name: "parent_id", type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isvalid = table.Column<bool>(name: "is_valid", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_children", x => x.Id);
                    table.ForeignKey(
                        name: "FK_children_parents_parent_id",
                        column: x => x.parentid,
                        principalSchema: "test",
                        principalTable: "parents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_children_parent_id",
                schema: "test",
                table: "children",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_parents_status_id",
                schema: "test",
                table: "parents",
                column: "status_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "children",
                schema: "test");

            migrationBuilder.DropTable(
                name: "parents",
                schema: "test");

            migrationBuilder.DropTable(
                name: "status",
                schema: "test");

            migrationBuilder.DropSequence(
                name: "childrenitemseq");

            migrationBuilder.DropSequence(
                name: "parentseq",
                schema: "test");
        }
    }
}
