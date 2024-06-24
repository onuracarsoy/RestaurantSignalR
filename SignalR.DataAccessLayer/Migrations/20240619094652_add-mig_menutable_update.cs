using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    public partial class addmig_menutable_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderTableNumber",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "MenuTableID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MenuTables",
                columns: table => new
                {
                    MenuTableID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuTables", x => x.MenuTableID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MenuTableID",
                table: "Orders",
                column: "MenuTableID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_MenuTables_MenuTableID",
                table: "Orders",
                column: "MenuTableID",
                principalTable: "MenuTables",
                principalColumn: "MenuTableID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_MenuTables_MenuTableID",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "MenuTables");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MenuTableID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MenuTableID",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "OrderTableNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
