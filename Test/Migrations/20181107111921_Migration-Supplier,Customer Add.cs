using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Test.Migrations
{
    public partial class MigrationSupplierCustomerAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Sales",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "Sales",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Due",
                table: "Sales",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNo",
                table: "Sales",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Paid",
                table: "Sales",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Due",
                table: "Purchases",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Paid",
                table: "Purchases",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                table: "Purchases",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Create = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<Guid>(nullable: false),
                    Due = table.Column<double>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Modify = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Paid = table.Column<double>(nullable: false),
                    Phone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierId = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    Company = table.Column<string>(nullable: true),
                    Create = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<Guid>(nullable: false),
                    Due = table.Column<double>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Modify = table.Column<DateTime>(nullable: false),
                    ModifyBy = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Paid = table.Column<double>(nullable: false),
                    Phone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_SupplierId",
                table: "Purchases",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Supplier_SupplierId",
                table: "Products",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Supplier_SupplierId",
                table: "Purchases",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Customer_CustomerId",
                table: "Sales",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Supplier_SupplierId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Supplier_SupplierId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Customer_CustomerId",
                table: "Sales");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_SupplierId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Products_SupplierId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Due",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "InvoiceNo",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Due",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Products");
        }
    }
}
