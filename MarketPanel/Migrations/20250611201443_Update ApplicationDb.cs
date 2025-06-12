using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketPanel.Migrations
{
    /// <inheritdoc />
    public partial class UpdateApplicationDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_saleItems_Products_ProductId",
                table: "saleItems");

            migrationBuilder.DropForeignKey(
                name: "FK_saleItems_saleDocuments_SaleDocumentId",
                table: "saleItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_saleItems",
                table: "saleItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_saleDocuments",
                table: "saleDocuments");

            migrationBuilder.RenameTable(
                name: "saleItems",
                newName: "SaleItems");

            migrationBuilder.RenameTable(
                name: "saleDocuments",
                newName: "SaleDocuments");

            migrationBuilder.RenameIndex(
                name: "IX_saleItems_SaleDocumentId",
                table: "SaleItems",
                newName: "IX_SaleItems_SaleDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_saleItems_ProductId",
                table: "SaleItems",
                newName: "IX_SaleItems_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleItems",
                table: "SaleItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleDocuments",
                table: "SaleDocuments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItems_Products_ProductId",
                table: "SaleItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItems_SaleDocuments_SaleDocumentId",
                table: "SaleItems",
                column: "SaleDocumentId",
                principalTable: "SaleDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleItems_Products_ProductId",
                table: "SaleItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleItems_SaleDocuments_SaleDocumentId",
                table: "SaleItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleItems",
                table: "SaleItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleDocuments",
                table: "SaleDocuments");

            migrationBuilder.RenameTable(
                name: "SaleItems",
                newName: "saleItems");

            migrationBuilder.RenameTable(
                name: "SaleDocuments",
                newName: "saleDocuments");

            migrationBuilder.RenameIndex(
                name: "IX_SaleItems_SaleDocumentId",
                table: "saleItems",
                newName: "IX_saleItems_SaleDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleItems_ProductId",
                table: "saleItems",
                newName: "IX_saleItems_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_saleItems",
                table: "saleItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_saleDocuments",
                table: "saleDocuments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_saleItems_Products_ProductId",
                table: "saleItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_saleItems_saleDocuments_SaleDocumentId",
                table: "saleItems",
                column: "SaleDocumentId",
                principalTable: "saleDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
