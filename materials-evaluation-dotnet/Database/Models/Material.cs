namespace MaterialsEvaluation.Database;

public class Material
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Material(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
