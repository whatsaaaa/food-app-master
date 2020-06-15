using Recipe.Application.Repositories;
using Recipe.Domain.Entities;

namespace Recipe.DataAccess.Repositories
{
    public class EfIngredientRepository : EfGenericRepository<Ingredient>, IIngredientRepository
    {
        public EfIngredientRepository(FoodDbContext context) : base(context)
        {
        }
    }
}
