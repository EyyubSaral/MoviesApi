using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Branda",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 8, 19, 13, 14, 43, 292, DateTimeKind.Local).AddTicks(1671), "Beauty & Tools" });

            migrationBuilder.UpdateData(
                table: "Branda",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 8, 19, 13, 14, 43, 292, DateTimeKind.Local).AddTicks(1644), "Sports & Tools" });

            migrationBuilder.UpdateData(
                table: "Branda",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 8, 19, 13, 14, 43, 292, DateTimeKind.Local).AddTicks(1765), "Tools & Grocery" });

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 19, 13, 14, 43, 292, DateTimeKind.Local).AddTicks(5241));

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 19, 13, 14, 43, 292, DateTimeKind.Local).AddTicks(5246));

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 19, 13, 14, 43, 292, DateTimeKind.Local).AddTicks(5249));

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 19, 13, 14, 43, 292, DateTimeKind.Local).AddTicks(5252));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 8, 19, 13, 14, 43, 296, DateTimeKind.Local).AddTicks(464), "Quasi ducimus quis alias ratione.", "Çıktılar." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 8, 19, 13, 14, 43, 296, DateTimeKind.Local).AddTicks(596), "Çıktılar olduğu illo olduğu adresini.", "Qui türemiş." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 8, 19, 13, 14, 43, 296, DateTimeKind.Local).AddTicks(684), "Voluptatem mutlu et dolor qui.", "Domates." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 8, 19, 13, 14, 43, 301, DateTimeKind.Local).AddTicks(1882), 9.778415766912570m, 247.80m, "Handmade Fresh Gloves" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 8, 19, 13, 14, 43, 301, DateTimeKind.Local).AddTicks(1939), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 6.998181566975870m, 930.77m, "Tasty Frozen Soap" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categorys_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Branda",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 8, 7, 13, 42, 37, 752, DateTimeKind.Local).AddTicks(7741), "Baby, Grocery & Games" });

            migrationBuilder.UpdateData(
                table: "Branda",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 8, 7, 13, 42, 37, 752, DateTimeKind.Local).AddTicks(7712), "Beauty & Automotive" });

            migrationBuilder.UpdateData(
                table: "Branda",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2025, 8, 7, 13, 42, 37, 752, DateTimeKind.Local).AddTicks(7759), "Shoes, Computers & Home" });

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 7, 13, 42, 37, 752, DateTimeKind.Local).AddTicks(9955));

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 7, 13, 42, 37, 752, DateTimeKind.Local).AddTicks(9957));

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 7, 13, 42, 37, 752, DateTimeKind.Local).AddTicks(9959));

            migrationBuilder.UpdateData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 8, 7, 13, 42, 37, 752, DateTimeKind.Local).AddTicks(9960));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 8, 7, 13, 42, 37, 754, DateTimeKind.Local).AddTicks(8294), "Fugit mutlu qui ullam sed.", "Aut." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 8, 7, 13, 42, 37, 754, DateTimeKind.Local).AddTicks(8344), "İpsam sit açılmadan explicabo alias.", "Telefonu consequuntur." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2025, 8, 7, 13, 42, 37, 754, DateTimeKind.Local).AddTicks(8429), "Un consequatur duyulmamış sed kutusu.", "Çobanın." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 8, 7, 13, 42, 37, 756, DateTimeKind.Local).AddTicks(4086), 1.961777123696570m, 642.13m, "Practical Fresh Cheese" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2025, 8, 7, 13, 42, 37, 756, DateTimeKind.Local).AddTicks(4163), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 3.944647469980930m, 436.51m, "Rustic Concrete Hat" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");
        }
    }
}
