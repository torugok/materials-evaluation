namespace MaterialsEvaluation.Database;

public class QualityVision
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int AvaliationMinQuantity { get; set; }
    public int AvaliationGrouping { get; set; }
    public int AvaliationCalculationType { get; set; }

    public Guid MaterialId { get; set; }
    public Material? Material { get; set; }

    public List<QualityVisionProperties>? QualityVisionProperties { get; set; }
}

public class QualityVisionProperties
{
    public Guid Id { get; set; }
    public Guid QualityVisionId { get; set; }
    public QualityVision? QualityVision { get; set; }

    public Guid QualityPropertyId { get; set; }
    public QualityProperty? QualityProperty { get; set; }
}
