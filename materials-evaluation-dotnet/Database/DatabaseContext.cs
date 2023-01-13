using Microsoft.EntityFrameworkCore;

namespace MaterialsEvaluation.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<Material> Materials { get; set; } = null!;
}
