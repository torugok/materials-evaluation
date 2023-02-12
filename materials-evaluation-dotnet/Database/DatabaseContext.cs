using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using MaterialsEvaluation.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.Database;

public class DatabaseContext : DbContext
{
    public DbSet<Material> Materials { get; set; } = null!;
    public DbSet<QualityProperty> QualityProperties { get; set; } = null!;
    public DbSet<QualityVision> QualityVisions { get; set; } = null!;
    public DbSet<QualityVisionProperties> QualityVisionProperties { get; set; } = null!;

    public DbSet<Batch> Batches { get; set; } = null!;
    public DbSet<Test> Tests { get; set; } = null!;

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
            .Entity<Batch>()
            .HasOne(e => e.QualityVision)
            .WithMany(e => e.Batches)
            .HasForeignKey(c => c.QualityVisionId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder
            .Entity<Test>()
            .HasOne(e => e.Batch)
            .WithMany(e => e.Tests)
            .HasForeignKey(c => c.BatchId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder
            .Entity<Test>()
            .HasOne(e => e.QualityProperty)
            .WithMany(e => e.Tests)
            .HasForeignKey(c => c.QualityPropertyId)
            .OnDelete(DeleteBehavior.Cascade);

        // Mapping Domain to EF
        modelBuilder.ApplyConfiguration(new MaterialMap());
    }
}
