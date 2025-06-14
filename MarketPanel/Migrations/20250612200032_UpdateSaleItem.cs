using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPanel.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSaleItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleItems_SaleDocuments_SaleDocumentId",
                table: "SaleItems");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "SaleDocuments");

            migrationBuilder.AlterColumn<long>(
                name: "SaleDocumentId",
                table: "SaleItems",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SaleDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItems_SaleDocuments_SaleDocumentId",
                table: "SaleItems",
                column: "SaleDocumentId",
                principalTable: "SaleDocuments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleItems_SaleDocuments_SaleDocumentId",
                table: "SaleItems");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SaleDocuments");

            migrationBuilder.AlterColumn<long>(
                name: "SaleDocumentId",
                table: "SaleItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "SaleDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItems_SaleDocuments_SaleDocumentId",
                table: "SaleItems",
                column: "SaleDocumentId",
                principalTable: "SaleDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
