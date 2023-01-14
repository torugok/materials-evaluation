namespace MaterialsEvaluation.Database;

public class QualityProperty
{
    public long Id { get; set; }
    public string? Acronym { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; }

    // Apenas para característica quantitativa
    // NOTE: Pode ter um jeito diferente de fazer isso, como um modelo especifico pra quantitativo?
    public int? QuantitativeDecimals { get; set; }
    public string? QuantitativeUnit { get; set; }
    public double? QuantitativeNominalValue { get; set; }
    public double? QuantitativeInferiorLimit { get; set; }
    public double? QuantitativeSuperiorLimit { get; set; }
}
