using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Test.Migrations
{
    public partial class TableGenerate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false),
                    Create = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<Guid>(nullable: false),
                    Modify = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    UnitMeasurement = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<Guid>(nullable: false),
                    Create = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<Guid>(nullable: false),
                    Modify = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<Guid>(nullable: false),
                    NoOfItem = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    TotalAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseId);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleId = table.Column<Guid>(nullable: false),
                    Create = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<Guid>(nullable: false),
                    Modify = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<Guid>(nullable: false),
                    NoOfItem = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    TotalAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetailses",
                columns: table => new
                {
                    PurchaseDetailsId = table.Column<Guid>(nullable: false),
                    MeasureType = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    PurchaseId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetailses", x => x.PurchaseDetailsId);
                    table.ForeignKey(
                        name: "FK_PurchaseDetailses_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseDetailses_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleDetailses",
                columns: table => new
                {
                    SaleDetailsId = table.Column<Guid>(nullable: false),
                    Create = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<Guid>(nullable: false),
                    MeasureType = table.Column<string>(nullable: false),
                    Modify = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<Guid>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    SaleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleDetailses", x => x.SaleDetailsId);
                    table.ForeignKey(
                        name: "FK_SaleDetailses_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleDetailses_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetailses_ProductId",
                table: "PurchaseDetailses",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetailses_PurchaseId",
                table: "PurchaseDetailses",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetailses_ProductId",
                table: "SaleDetailses",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetailses_SaleId",
                table: "SaleDetailses",
                column: "SaleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseDetailses");

            migrationBuilder.DropTable(
                name: "SaleDetailses");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sales");
        }
    }
}
