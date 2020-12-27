using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demirqol.Delivery.Migrations
{
    public partial class ProdInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MD_Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MD_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MD_Item",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Barcode = table.Column<string>(maxLength: 100, nullable: true),
                    Price = table.Column<double>(nullable: false),
                    OldPrice = table.Column<double>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    OnStock = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MD_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MD_Market",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Address = table.Column<string>(maxLength: 250, nullable: true),
                    Latitude = table.Column<double>(nullable: true),
                    Longitude = table.Column<double>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MD_Market", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OP_Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MarketId = table.Column<int>(nullable: true),
                    DeliveryUserId = table.Column<Guid>(nullable: true),
                    OrderStatus = table.Column<int>(nullable: false),
                    OrderStatusDescription = table.Column<string>(maxLength: 250, nullable: true),
                    TenantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OP_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OP_UserPosition",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OP_UserPosition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OP_OrderLine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OP_OrderLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OP_OrderLine_OP_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OP_Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MD_Item_CategoryId",
                table: "MD_Item",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MD_Item_Name",
                table: "MD_Item",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_MD_Item_OnStock",
                table: "MD_Item",
                column: "OnStock");

            migrationBuilder.CreateIndex(
                name: "IX_MD_Item_TenantId",
                table: "MD_Item",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_MD_Market_TenantId",
                table: "MD_Market",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_MD_Market_Latitude_Longitude",
                table: "MD_Market",
                columns: new[] { "Latitude", "Longitude" });

            migrationBuilder.CreateIndex(
                name: "IX_OP_Order_CreatorId",
                table: "OP_Order",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_OP_Order_DeliveryUserId",
                table: "OP_Order",
                column: "DeliveryUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OP_Order_OrderStatus",
                table: "OP_Order",
                column: "OrderStatus");

            migrationBuilder.CreateIndex(
                name: "IX_OP_Order_TenantId",
                table: "OP_Order",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_OP_OrderLine_OrderId",
                table: "OP_OrderLine",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OP_UserPosition_Latitude_Longitude",
                table: "OP_UserPosition",
                columns: new[] { "Latitude", "Longitude" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MD_Category");

            migrationBuilder.DropTable(
                name: "MD_Item");

            migrationBuilder.DropTable(
                name: "MD_Market");

            migrationBuilder.DropTable(
                name: "OP_OrderLine");

            migrationBuilder.DropTable(
                name: "OP_UserPosition");

            migrationBuilder.DropTable(
                name: "OP_Order");
        }
    }
}
