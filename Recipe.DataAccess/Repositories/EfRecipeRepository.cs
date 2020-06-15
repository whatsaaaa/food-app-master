using Recipe.Application.Repositories;

namespace Recipe.DataAccess.Repositories
{
    public class EfRecipeRepository : EfGenericRepository<Domain.Entities.Recipe>, IRecipeRepository
    {
        public EfRecipeRepository(FoodDbContext context) : base(context)
        {
        }
    }
}
