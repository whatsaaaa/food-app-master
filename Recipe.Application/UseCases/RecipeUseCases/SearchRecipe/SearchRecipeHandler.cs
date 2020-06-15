using MediatR;
using Recipe.Application.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Recipe.Application.UseCases.RecipeUseCases.SearchRecipe
{
    public class SearchRecipeHandler : IRequestHandler<SearchRecipeQuery, IEnumerable<RecipeDto>>
    {
        private readonly IRecipeRepository _repo;

        public SearchRecipeHandler(IRecipeRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<RecipeDto>> Handle(SearchRecipeQuery request, CancellationToken cancellationToken)
        {
            var result = _repo.Get(request.AsQuery, request.PerPage, request.PageNumber);

            return Task.FromResult(result.Select(r => new RecipeDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Keyword = r.Keyword,
                PostedOn = r.CreatedAt
            }));
        }
    }
}
