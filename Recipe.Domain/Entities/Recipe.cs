using System.Collections.Generic;

namespace Recipe.Domain.Entities
{
    public class Recipe : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
