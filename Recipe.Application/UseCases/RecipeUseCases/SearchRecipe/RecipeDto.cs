using System;

namespace Recipe.Application.UseCases.RecipeUseCases.SearchRecipe
{
    public class RecipeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }
        public DateTime PostedOn { get; set; }
        public int Id { get; set; }
    }
}
