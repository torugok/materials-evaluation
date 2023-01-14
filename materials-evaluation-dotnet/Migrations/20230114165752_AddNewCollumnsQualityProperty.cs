using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaterialsEvaluation.Migrations
{
    /// <inheritdoc />
    public partial class AddNewCollumnsQualityProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantitativeDecimals",
                table: "QualityProperties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "QuantitativeInferiorLimit",
                table: "QualityProperties",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "QuantitativeNominalValue",
                table: "QualityProperties",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "QuantitativeSuperiorLimit",
                table: "QualityProperties",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuantitativeUnit",
                table: "QualityProperties",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantitativeDecimals",
                table: "QualityProperties");

            migrationBuilder.DropColumn(
                name: "QuantitativeInferiorLimit",
                table: "QualityProperties");

            migrationBuilder.DropColumn(
                name: "QuantitativeNominalValue",
                table: "QualityProperties");

            migrationBuilder.DropColumn(
                name: "QuantitativeSuperiorLimit",
                table: "QualityProperties");

            migrationBuilder.DropColumn(
                name: "QuantitativeUnit",
                table: "QualityProperties");
        }
    }
}
