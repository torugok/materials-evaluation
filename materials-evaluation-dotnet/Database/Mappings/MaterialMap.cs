using MaterialsEvaluation.Modules.QualityEvaluation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaterialsEvaluation.Database
{
    public class MaterialMap : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Ignore(b => b.DomainEvents);

            builder.Property(c => c.Name);
        }
    }
}
