using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaterialsEvaluation.Migrations
{
    /// <inheritdoc />
    public partial class AddChangesInBatches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialBatchTests");

            migrationBuilder.DropTable(
                name: "MaterialBatches");

            migrationBuilder.CreateTable(
                name: "Batches",
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
                    table.PrimaryKey("PK_Batches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Batches_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Batches_QualityVisions_QualityVisionId",
                        column: x => x.QualityVisionId,
                        principalTable: "QualityVisions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    BatchId = table.Column<Guid>(type: "TEXT", nullable: false),
                    QualityPropertyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ResultQualitative = table.Column<bool>(type: "INTEGER", nullable: true),
                    ResultQuantitative = table.Column<double>(type: "REAL", nullable: true),
                    Passed = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tests_QualityProperties_QualityPropertyId",
                        column: x => x.QualityPropertyId,
                        principalTable: "QualityProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batches_MaterialId",
                table: "Batches",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_QualityVisionId",
                table: "Batches",
                column: "QualityVisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_BatchId",
                table: "Tests",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_QualityPropertyId",
                table: "Tests",
                column: "QualityPropertyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Batches");

            migrationBuilder.CreateTable(
                name: "MaterialBatches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MaterialId = table.Column<Guid>(type: "TEXT", nullable: false),
                    QualityVisionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AmountOfTests = table.Column<int>(type: "INTEGER", nullable: false),
                    CalculatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
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
        }
    }
}
