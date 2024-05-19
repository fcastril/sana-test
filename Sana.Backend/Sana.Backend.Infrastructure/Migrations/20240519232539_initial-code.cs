using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sana.Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Cellphone = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "dbo",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "dbo",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "dbo",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Category",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { new Guid("1c284f34-a2e9-42ab-9060-3e01a182a66e"), "0003", "Tablets" },
                    { new Guid("b087fc74-f27d-45fe-adec-27230ee0f0e0"), "0002", "Laptops" },
                    { new Guid("eb4e9609-e88e-43cb-ac4f-06a0c1695de6"), "0001", "Computers" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Customer",
                columns: new[] { "Id", "Address", "Cellphone", "City", "Document", "Email", "Name", "Telephone" },
                values: new object[,]
                {
                    { new Guid("24d55461-85b4-411d-a75c-d20bf80eec7c"), "Calle principal via al Centro Km 12 Casa 3", "4320987771", "Los Angeles - California - EEUU", "98123456", "", "Robert C. Martin", "4320987771" },
                    { new Guid("a9706c0d-d4c8-4c09-8d87-6dbd3554f5e4"), "Hatillo frente a la iglesia Santa Marta", "3137977225", "Barbosa - Antioquia - Colombia", "71775186", "", "Fabian Mauricio Castrillon Franco", "3137977225" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Code", "Name", "Price", "Stock", "UrlImage" },
                values: new object[,]
                {
                    { new Guid("228f253b-43e5-4b19-88ea-912c20011c74"), new Guid("1c284f34-a2e9-42ab-9060-3e01a182a66e"), "PR005", "Apple iPad (9ª generación) 10.2\" Wi-Fi 64GB - Gris espacial ", 2200000m, 2, "https://http2.mlstatic.com/D_NQ_NP_912069-MLA74807972777_022024-O.jpg" },
                    { new Guid("37843d1a-daea-47a6-9970-e03faa430190"), new Guid("eb4e9609-e88e-43cb-ac4f-06a0c1695de6"), "PR002", "Torre Cpu Gamer Athlon 3000g Vega 3 1tb 16gb Led 22 Pc", 1529000m, 5, "https://http2.mlstatic.com/D_NQ_NP_674835-MCO71845670112_092023-O.jpg" },
                    { new Guid("4ba835ec-351a-4bff-8582-27664624e0fd"), new Guid("b087fc74-f27d-45fe-adec-27230ee0f0e0"), "PR007", "Mac Air 2020 Pulgadas I7 + 16gb + 500 Ssd Como Nuevo En Caja", 5800000m, 1, "https://http2.mlstatic.com/D_NQ_NP_607176-MCO69416858664_052023-O.jpg" },
                    { new Guid("6fe135d8-1242-448b-b605-092431c2dd45"), new Guid("eb4e9609-e88e-43cb-ac4f-06a0c1695de6"), "PR001", "Torre Gamer Amd Ryzen 5 5600g +16gb Ram +ssd 240 Radeon 7 P", 1539000m, 10, "https://http2.mlstatic.com/D_NQ_NP_890513-MCO72408954235_102023-O.jpg" },
                    { new Guid("8485b9bb-c0d7-45e5-bfb3-a9966851baf9"), new Guid("1c284f34-a2e9-42ab-9060-3e01a182a66e"), "PR006", "iPad Apple Pro 4th generation 4th generation A2759 11\" 128GB gris espacial y 8GB de memoria RAM ", 3500000m, 1, "https://http2.mlstatic.com/D_NQ_NP_893788-MLA52850734025_122022-O.jpg" },
                    { new Guid("aa66e380-29f9-48da-8b2d-6c4cb9cae4fe"), new Guid("eb4e9609-e88e-43cb-ac4f-06a0c1695de6"), "PR003", "Cpu Torre Core I5 +16ram+hd500 Monitor 19 (Reacondicionado)", 713000m, 3, "https://http2.mlstatic.com/D_NQ_NP_956627-MCO75513168527_042024-O.jpg" },
                    { new Guid("c2578b06-94ca-4c9a-b3b5-8c2b4391137f"), new Guid("eb4e9609-e88e-43cb-ac4f-06a0c1695de6"), "PR004", "Cpu Intel Core I5 Tercera Generacion Ssd 480 Gb Ram 8gb", 630000m, 1, "https://http2.mlstatic.com/D_NQ_NP_942517-MCO54964311414_042023-O.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                schema: "dbo",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                schema: "dbo",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                schema: "dbo",
                table: "OrderDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                schema: "dbo",
                table: "Product",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "dbo");
        }
    }
}
