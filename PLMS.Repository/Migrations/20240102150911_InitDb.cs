using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PLMS.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeletedById = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IsDeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeactived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeactivedById = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IsDeactivedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeletedById = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IsDeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeactived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeactivedById = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IsDeactivedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SizeSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeletedById = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IsDeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeactived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeactivedById = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IsDeactivedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ModelGroupId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeletedById = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IsDeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeactived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeactivedById = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IsDeactivedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_ModelGroups_ModelGroupId",
                        column: x => x.ModelGroupId,
                        principalTable: "ModelGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SizeSetId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeletedById = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IsDeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeactived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeactivedById = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IsDeactivedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sizes_SizeSets_SizeSetId",
                        column: x => x.SizeSetId,
                        principalTable: "SizeSets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PlanningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShipmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModelId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeletedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeactived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeactivedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactivedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    SizeSetId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeletedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeactived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeactivedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactivedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItems_SizeSets_SizeSetId",
                        column: x => x.SizeSetId,
                        principalTable: "SizeSets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItemRecipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderItemId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeletedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeactived = table.Column<bool>(type: "bit", nullable: false),
                    IsDeactivedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeactivedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItemRecipes_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItemRecipes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Models_ModelGroupId",
                table: "Models",
                column: "ModelGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemRecipes_OrderItemId",
                table: "OrderItemRecipes",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemRecipes_SizeId",
                table: "OrderItemRecipes",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ColorId",
                table: "OrderItems",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_SizeSetId",
                table: "OrderItems",
                column: "SizeSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ModelId",
                table: "Orders",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_SizeSetId",
                table: "Sizes",
                column: "SizeSetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItemRecipes");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "SizeSets");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "ModelGroups");
        }
    }
}
