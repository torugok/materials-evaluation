using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaterialsEvaluation.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityProperties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Acronym = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantitativeDecimals = table.Column<int>(type: "int", nullable: true),
                    QuantitativeUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantitativeNominalValue = table.Column<double>(type: "float", nullable: true),
                    QuantitativeInferiorLimit = table.Column<double>(type: "float", nullable: true),
                    QuantitativeSuperiorLimit = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityVisions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvaliationMinQuantity = table.Column<int>(type: "int", nullable: false),
                    AvaliationGrouping = table.Column<int>(type: "int", nullable: false),
                    AvaliationCalculationType = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityVisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityVisions_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QualityVisionProperties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QualityVisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QualityPropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityVisionProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityVisionProperties_QualityProperties_QualityPropertyId",
                        column: x => x.QualityPropertyId,
                        principalTable: "QualityProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QualityVisionProperties_QualityVisions_QualityVisionId",
                        column: x => x.QualityVisionId,
                        principalTable: "QualityVisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QualityVisionProperties_QualityPropertyId",
                table: "QualityVisionProperties",
                column: "QualityPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityVisionProperties_QualityVisionId",
                table: "QualityVisionProperties",
                column: "QualityVisionId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityVisions_MaterialId",
                table: "QualityVisions",
                column: "MaterialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QualityVisionProperties");

            migrationBuilder.DropTable(
                name: "QualityProperties");

            migrationBuilder.DropTable(
                name: "QualityVisions");

            migrationBuilder.DropTable(
                name: "Materials");
        }
    }
}
