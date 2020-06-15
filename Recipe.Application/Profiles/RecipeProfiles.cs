using AutoMapper;
using Recipe.Application.UseCases.RecipeUseCases.AddRecipe;
using Recipe.Application.UseCases.RecipeUseCases.SearchRecipe;
using Recipe.Application.UseCases.RecipeUseCases.UpdateRecipe;

namespace Recipe.Application.Profiles
{
    public class RecipeProfiles : Profile
    {
        public RecipeProfiles()
        {
            CreateMap<AddRecipeUseCase, Domain.Entities.Recipe>();
            CreateMap<UpdateRecipeRequest, Domain.Entities.Recipe>();
            CreateMap<Domain.Entities.Recipe, RecipeDto>();
        }
    }
}
