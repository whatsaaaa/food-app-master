using MediatR;
using Recipe.Application.Exceptions;
using Recipe.Application.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Recipe.Application.UseCases.RecipeUseCases.DeleteRecipe
{
    public class DeleteRecipeHandler : IRequestHandler<DeleteRecipeRequest>
    {
        private readonly IRecipeRepository _repo;

        public DeleteRecipeHandler(IRecipeRepository repo)
        {
            _repo = repo;
        }

        public Task<Unit> Handle(DeleteRecipeRequest request, CancellationToken cancellationToken)
        {
            var recipe = _repo.Get(request.Id);

            if (recipe == null)
            {
                throw new EntityNotFoundException(request.Id, "Recipe");
            }

            _repo.Delete(request.Id);

            return Unit.Task;
        }
    }
}
