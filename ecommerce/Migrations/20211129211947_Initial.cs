using Microsoft.EntityFrameworkCore.Migrations;

namespace ecommerce.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    BuyerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyerİmgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyerMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyerPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.BuyerId);
                });

            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    Categoryİd = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.Categoryİd);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Sellerİd = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellerİmgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Sellerİd);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Productİd = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductİmgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCategory = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    BuyerBasketBuyerId = table.Column<int>(type: "int", nullable: true),
                    BuyerBasketProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Productİd);
                    table.ForeignKey(
                        name: "FK_Products_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "Categoryİd",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Sellerİd",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuyerBaskets",
                columns: table => new
                {
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    BuyerBasketId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerBaskets", x => new { x.BuyerId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_BuyerBaskets_Buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Buyers",
                        principalColumn: "BuyerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyerBaskets_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Productİd",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyerBaskets_ProductId",
                table: "BuyerBaskets",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BuyerBasketBuyerId_BuyerBasketProductId",
                table: "Products",
                columns: new[] { "BuyerBasketBuyerId", "BuyerBasketProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SellerId",
                table: "Products",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_BuyerBaskets_BuyerBasketBuyerId_BuyerBasketProductId",
                table: "Products",
                columns: new[] { "BuyerBasketBuyerId", "BuyerBasketProductId" },
                principalTable: "BuyerBaskets",
                principalColumns: new[] { "BuyerId", "ProductId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyerBaskets_Buyers_BuyerId",
                table: "BuyerBaskets");

            migrationBuilder.DropForeignKey(
                name: "FK_BuyerBaskets_Products_ProductId",
                table: "BuyerBaskets");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "BuyerBaskets");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "Sellers");
        }
    }
}
