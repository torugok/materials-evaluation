using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.Database;

public class DatabaseContext : DbContext
{
    public DbSet<Material> Materials { get; set; } = null!;
    public DbSet<QualityProperty> QualityProperties { get; set; } = null!;
    public DbSet<QualityVision> QualityVisions { get; set; } = null!;
    public DbSet<QualityVisionProperties> QualityVisionProperties { get; set; } = null!;

    public DbSet<MaterialBatch> MaterialBatches { get; set; } = null!;
    public DbSet<MaterialBatchTests> MaterialBatchTests { get; set; } = null!;

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
        // FIXME: Substituir para outra abordagem, não recomendada por: https://learn.microsoft.com/pt-br/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli#apply-migrations-at-runtime
        this.Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QualityVisionProperties>(
            b => b.HasIndex(e => new { e.QualityVisionId, e.QualityPropertyId }).IsUnique()
        );

        modelBuilder
            .Entity<MaterialBatch>()
            .HasOne(e => e.QualityVision)
            .WithMany(e => e.MaterialBatches)
            .HasForeignKey(c => c.QualityVisionId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder
            .Entity<MaterialBatchTests>()
            .HasOne(e => e.MaterialBatch)
            .WithMany(e => e.MaterialBatchTests)
            .HasForeignKey(c => c.MaterialBatchId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder
            .Entity<MaterialBatchTests>()
            .HasOne(e => e.QualityProperty)
            .WithMany(e => e.MaterialBatchTests)
            .HasForeignKey(c => c.QualityPropertyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
