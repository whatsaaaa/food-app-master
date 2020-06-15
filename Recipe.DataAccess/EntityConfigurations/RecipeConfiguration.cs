using Microsoft.EntityFrameworkCore;

namespace Recipe.DataAccess.EntityConfigurations
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Domain.Entities.Recipe>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Entities.Recipe> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(5000);
            builder.Property(e => e.Keyword)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
