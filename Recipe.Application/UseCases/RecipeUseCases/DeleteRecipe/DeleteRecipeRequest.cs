using MediatR;

namespace Recipe.Application.UseCases.RecipeUseCases.DeleteRecipe
{
    public class DeleteRecipeRequest : IRequest
    {
        public int Id { get; set; }
    }
}
