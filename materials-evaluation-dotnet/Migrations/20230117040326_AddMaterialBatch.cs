using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaterialsEvaluation.Migrations
{
    /// <inheritdoc />
    public partial class AddMaterialBatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialBatches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QualityVisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountOfTests = table.Column<int>(type: "int", nullable: false),
                    CalculatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaterialBatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QualityPropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResultQualitative = table.Column<bool>(type: "bit", nullable: true),
                    ResultQuantitative = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialBatchTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialBatchTests_MaterialBatches_MaterialBatchId",
                        column: x => x.MaterialBatchId,
                        principalTable: "MaterialBatches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaterialBatchTests_QualityProperties_QualityPropertyId",
                        column: x => x.QualityPropertyId,
                        principalTable: "QualityProperties",
                        principalColumn: "Id");
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialBatchTests");

            migrationBuilder.DropTable(
                name: "MaterialBatches");
        }
    }
}
