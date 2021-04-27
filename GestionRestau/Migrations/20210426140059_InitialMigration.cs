using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionRestau.Migrations
{
    
    //pour generer cette class on doit utiliser commande add-migration (view, other Windows, Package Manager Console) apres update-database 
    public partial class InitialMigration : Migration
    {
        
        // ce que on doit ajouter
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prix = table.Column<float>(type: "real", nullable: false),
                    Categorie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CentreDeRevenu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nbpersonne = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableCmds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    NbPlace = table.Column<int>(type: "int", nullable: false),
                    Occupation = table.Column<bool>(type: "bit", nullable: false),
                    Emplacement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServeurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableCmds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableCmds_Servers_ServeurId",
                        column: x => x.ServeurId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consommations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    Paye = table.Column<bool>(type: "bit", nullable: false),
                    TableConsId = table.Column<int>(type: "int", nullable: true),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    ProduitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consommations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consommations_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consommations_TableCmds_TableConsId",
                        column: x => x.TableConsId,
                        principalTable: "TableCmds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consommations_ProduitId",
                table: "Consommations",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_Consommations_TableConsId",
                table: "Consommations",
                column: "TableConsId");

            migrationBuilder.CreateIndex(
                name: "IX_TableCmds_ServeurId",
                table: "TableCmds",
                column: "ServeurId");
        }

       
        // ce que on doit supperimer 
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consommations");

            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "TableCmds");

            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}
