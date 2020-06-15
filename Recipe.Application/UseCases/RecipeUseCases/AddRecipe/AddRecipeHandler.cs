using EventBus;
using EventBus.Events;
using MediatR;
using Recipe.Application.Exceptions;
using Recipe.Application.Repositories;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Recipe.Application.UseCases.RecipeUseCases.AddRecipe
{
    public class AddRecipeHandler : IRequestHandler<AddRecipeUseCase>
    {
        private readonly IRecipeRepository _repo;
        private readonly IEventBus _bus;

        public AddRecipeHandler(IRecipeRepository repo, IEventBus bus)
        {
            _repo = repo;
            _bus = bus;
        }

        public Task<Unit> Handle(AddRecipeUseCase request, CancellationToken cancellationToken)
        {
            if (_repo.Get(r => r.Name.ToLower() == request.Name.ToLower()).Any())
            {
                throw new EntityAlreadyExistsException($"{request.Name} is already in use.");
            }

            _repo.Add(new Domain.Entities.Recipe
            {
                Name = request.Name,
                Description = request.Description,
                Keyword = request.Keyword
            });

            _bus.Publish(new RecipeCreatedEvent()
            {
                DateCreated = DateTime.Now,
                RecipeName = request.Name,
                Email = "no-reply@email.com",
                Username = "Neki Korisnik"
            });

            return Unit.Task;
        }
    }
}
