using System.Collections.Generic;

namespace Recipe.Domain.Entities
{
    public class Ingredient : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
