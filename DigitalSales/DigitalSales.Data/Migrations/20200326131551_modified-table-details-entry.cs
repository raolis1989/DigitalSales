using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalSales.Data.Migrations
{
    public partial class modifiedtabledetailsentry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    IdCategory = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    Condition = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.IdCategory);
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    IdPerson = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type_person = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Type_document = table.Column<string>(nullable: true),
                    Num_document = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.IdPerson);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    idRole = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    Condition = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.idRole);
                });

            migrationBuilder.CreateTable(
                name: "article",
                columns: table => new
                {
                    IdArticle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCategory = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Price_Sale = table.Column<decimal>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Condition = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article", x => x.IdArticle);
                    table.ForeignKey(
                        name: "FK_article_category_idCategory",
                        column: x => x.idCategory,
                        principalTable: "category",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    idUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idRole = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Type_Document = table.Column<string>(nullable: true),
                    Num_Document = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Password_Hash = table.Column<byte[]>(nullable: false),
                    Password_Salt = table.Column<byte[]>(nullable: false),
                    Condition = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.idUser);
                    table.ForeignKey(
                        name: "FK_users_role_idRole",
                        column: x => x.idRole,
                        principalTable: "role",
                        principalColumn: "idRole",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "entry",
                columns: table => new
                {
                    identry = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idprovider = table.Column<int>(nullable: false),
                    iduser = table.Column<int>(nullable: false),
                    type_voucher = table.Column<string>(nullable: false),
                    num_voucher = table.Column<string>(nullable: false),
                    date_time = table.Column<DateTime>(nullable: false),
                    tax = table.Column<decimal>(nullable: false),
                    total = table.Column<decimal>(nullable: false),
                    status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entry", x => x.identry);
                    table.ForeignKey(
                        name: "FK_entry_person_idprovider",
                        column: x => x.idprovider,
                        principalTable: "person",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_entry_users_iduser",
                        column: x => x.iduser,
                        principalTable: "users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detail_entry",
                columns: table => new
                {
                    iddetail_entry = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    identry = table.Column<int>(nullable: false),
                    idarticle = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detail_entry", x => x.iddetail_entry);
                    table.ForeignKey(
                        name: "FK_detail_entry_entry_identry",
                        column: x => x.identry,
                        principalTable: "entry",
                        principalColumn: "identry",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_article_idCategory",
                table: "article",
                column: "idCategory");

            migrationBuilder.CreateIndex(
                name: "IX_detail_entry_identry",
                table: "detail_entry",
                column: "identry");

            migrationBuilder.CreateIndex(
                name: "IX_entry_idprovider",
                table: "entry",
                column: "idprovider");

            migrationBuilder.CreateIndex(
                name: "IX_entry_iduser",
                table: "entry",
                column: "iduser");

            migrationBuilder.CreateIndex(
                name: "IX_users_idRole",
                table: "users",
                column: "idRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "article");

            migrationBuilder.DropTable(
                name: "detail_entry");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "entry");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
