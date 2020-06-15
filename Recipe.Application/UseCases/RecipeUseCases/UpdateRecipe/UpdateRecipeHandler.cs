using MediatR;
using Recipe.Application.Exceptions;
using Recipe.Application.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Recipe.Application.UseCases.RecipeUseCases.UpdateRecipe
{
    public class UpdateRecipeHandler : IRequestHandler<UpdateRecipeRequest>
    {
        private readonly IRecipeRepository _repo;

        public UpdateRecipeHandler(IRecipeRepository repo)
        {
            _repo = repo;
        }

        public Task<Unit> Handle(UpdateRecipeRequest request, CancellationToken cancellationToken)
        {
            var recipe = _repo.Get(request.Id);

            if (recipe == null)
            {
                throw new EntityNotFoundException(request.Id, "Recipe");
            }

            recipe.Name = request.Name;
            recipe.Description = request.Description;
            recipe.Keyword = request.Keyword;

            _repo.Update(recipe);

            return Unit.Task;
        }
    }
}
