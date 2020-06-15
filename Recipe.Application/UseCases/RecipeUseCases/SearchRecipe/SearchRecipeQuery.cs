using MediatR;
using Recipe.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Recipe.Application.UseCases.RecipeUseCases.SearchRecipe
{
    public class SearchRecipeQuery : IRequest<IEnumerable<RecipeDto>>, IQuery<Domain.Entities.Recipe>
    {
        public string Keyword { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PerPage { get; set; } = 50;

        public string KeywordLower => Keyword?.ToLower();

        public Expression<Func<Domain.Entities.Recipe, bool>> AsQuery
        {
            get
            {
                if (Keyword == null)
                {
                    return r => r.Name != "";
                }

                return r =>
                    (r.Id.ToString() == KeywordLower);
            }
        }
    }
}
