using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipe.Domain.Entities;

namespace Recipe.DataAccess.EntityConfigurations
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
