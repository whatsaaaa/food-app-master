using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Recipe.Application.UseCases.RecipeUseCases.UpdateRecipe
{
    public class UpdateRecipeRequest : IRequest
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Keyword is required.")]
        public string Keyword { get; set; }
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }
    }
}
