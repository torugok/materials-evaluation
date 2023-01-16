using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaterialsEvaluation.Migrations
{
    /// <inheritdoc />
    public partial class AddFluentApiIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_QualityVisionProperties_QualityVisionId",
                table: "QualityVisionProperties");

            migrationBuilder.CreateIndex(
                name: "IX_QualityVisionProperties_QualityVisionId_QualityPropertyId",
                table: "QualityVisionProperties",
                columns: new[] { "QualityVisionId", "QualityPropertyId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_QualityVisionProperties_QualityVisionId_QualityPropertyId",
                table: "QualityVisionProperties");

            migrationBuilder.CreateIndex(
                name: "IX_QualityVisionProperties_QualityVisionId",
                table: "QualityVisionProperties",
                column: "QualityVisionId");
        }
    }
}
