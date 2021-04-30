using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionRestau.Migrations
{
    public partial class serveur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TableCmds_Servers_ServeurId",
                table: "TableCmds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Servers",
                table: "Servers");

            migrationBuilder.RenameTable(
                name: "Servers",
                newName: "Serveurs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Serveurs",
                table: "Serveurs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TableCmds_Serveurs_ServeurId",
                table: "TableCmds",
                column: "ServeurId",
                principalTable: "Serveurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TableCmds_Serveurs_ServeurId",
                table: "TableCmds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Serveurs",
                table: "Serveurs");

            migrationBuilder.RenameTable(
                name: "Serveurs",
                newName: "Servers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Servers",
                table: "Servers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TableCmds_Servers_ServeurId",
                table: "TableCmds",
                column: "ServeurId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
