using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaterialsEvaluation.Migrations
{
    /// <inheritdoc />
    public partial class ChangeKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialBatchTests_MaterialBatches_MaterialBatchId",
                table: "MaterialBatchTests");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialBatchTests_QualityProperties_QualityPropertyId",
                table: "MaterialBatchTests");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialBatchTests_MaterialBatches_MaterialBatchId",
                table: "MaterialBatchTests",
                column: "MaterialBatchId",
                principalTable: "MaterialBatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialBatchTests_QualityProperties_QualityPropertyId",
                table: "MaterialBatchTests",
                column: "QualityPropertyId",
                principalTable: "QualityProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialBatchTests_MaterialBatches_MaterialBatchId",
                table: "MaterialBatchTests");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialBatchTests_QualityProperties_QualityPropertyId",
                table: "MaterialBatchTests");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialBatchTests_MaterialBatches_MaterialBatchId",
                table: "MaterialBatchTests",
                column: "MaterialBatchId",
                principalTable: "MaterialBatches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialBatchTests_QualityProperties_QualityPropertyId",
                table: "MaterialBatchTests",
                column: "QualityPropertyId",
                principalTable: "QualityProperties",
                principalColumn: "Id");
        }
    }
}
