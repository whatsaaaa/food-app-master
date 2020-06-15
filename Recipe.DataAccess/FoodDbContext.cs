using Microsoft.EntityFrameworkCore;
using Recipe.DataAccess.EntityConfigurations;
using Recipe.DataAccess.Extensions;
using Recipe.Domain.Entities;

namespace Recipe.DataAccess
{
    public class FoodDbContext : DbContext
    {
        public FoodDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecipeConfiguration());
            modelBuilder.ApplyConfiguration(new IngredientConfiguration());
            modelBuilder.ApplyConfiguration(new RecipeIngredientConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries();
            entries.SetCreatedUpdatedAtDates();
            return base.SaveChanges();
        }

        public DbSet<Domain.Entities.Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
