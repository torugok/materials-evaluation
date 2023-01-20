using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaterialsEvaluation.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrationSqlite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityProperties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Acronym = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    QuantitativeDecimals = table.Column<int>(type: "INTEGER", nullable: true),
                    QuantitativeUnit = table.Column<string>(type: "TEXT", nullable: true),
                    QuantitativeNominalValue = table.Column<double>(type: "REAL", nullable: true),
                    QuantitativeInferiorLimit = table.Column<double>(type: "REAL", nullable: true),
                    QuantitativeSuperiorLimit = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityVisions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    AvaliationMinQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    AvaliationGrouping = table.Column<string>(type: "TEXT", nullable: false),
                    AvaliationCalculationType = table.Column<string>(type: "TEXT", nullable: false),
                    MaterialId = table.Column<Guid>(type: "TEXT", nullable: false)
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
                name: "MaterialBatches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MaterialId = table.Column<Guid>(type: "TEXT", nullable: false),
                    QualityVisionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AmountOfTests = table.Column<int>(type: "INTEGER", nullable: false),
                    CalculatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialBatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialBatches_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialBatches_QualityVisions_QualityVisionId",
                        column: x => x.QualityVisionId,
                        principalTable: "QualityVisions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QualityVisionProperties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    QualityVisionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    QualityPropertyId = table.Column<Guid>(type: "TEXT", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "MaterialBatchTests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MaterialBatchId = table.Column<Guid>(type: "TEXT", nullable: false),
                    QualityPropertyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ResultQualitative = table.Column<bool>(type: "INTEGER", nullable: true),
                    ResultQuantitative = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialBatchTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialBatchTests_MaterialBatches_MaterialBatchId",
                        column: x => x.MaterialBatchId,
                        principalTable: "MaterialBatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialBatchTests_QualityProperties_QualityPropertyId",
                        column: x => x.QualityPropertyId,
                        principalTable: "QualityProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialBatches_MaterialId",
                table: "MaterialBatches",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialBatches_QualityVisionId",
                table: "MaterialBatches",
                column: "QualityVisionId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialBatchTests_MaterialBatchId",
                table: "MaterialBatchTests",
                column: "MaterialBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialBatchTests_QualityPropertyId",
                table: "MaterialBatchTests",
                column: "QualityPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityVisionProperties_QualityPropertyId",
                table: "QualityVisionProperties",
                column: "QualityPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityVisionProperties_QualityVisionId_QualityPropertyId",
                table: "QualityVisionProperties",
                columns: new[] { "QualityVisionId", "QualityPropertyId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QualityVisions_MaterialId",
                table: "QualityVisions",
                column: "MaterialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialBatchTests");

            migrationBuilder.DropTable(
                name: "QualityVisionProperties");

            migrationBuilder.DropTable(
                name: "MaterialBatches");

            migrationBuilder.DropTable(
                name: "QualityProperties");

            migrationBuilder.DropTable(
                name: "QualityVisions");

            migrationBuilder.DropTable(
                name: "Materials");
        }
    }
}
