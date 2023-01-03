using Microsoft.EntityFrameworkCore.Migrations;

namespace digitaldiaryBackend.Migrations
{
    public partial class EventMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblEvent",
                columns: table => new
                {
                    eid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uid = table.Column<int>(nullable: false),
                    sdate = table.Column<string>(nullable: true),
                    edate = table.Column<string>(nullable: true),
                    time = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEvent", x => x.eid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblEvent");
        }
    }
}
