using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        // HACK: Substituir para outra abordagem, não recomendada por: https://learn.microsoft.com/pt-br/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli#apply-migrations-at-runtime
        this.Database.Migrate();
    }

    public DbSet<Material> Materials { get; set; } = null!;
    public DbSet<QualityProperty> QualityProperties { get; set; } = null!;
}
