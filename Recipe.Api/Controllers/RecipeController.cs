using MediatR;
using Microsoft.AspNetCore.Mvc;
using Recipe.Application.Exceptions;
using Recipe.Application.UseCases.RecipeUseCases.AddRecipe;
using Recipe.Application.UseCases.RecipeUseCases.DeleteRecipe;
using Recipe.Application.UseCases.RecipeUseCases.SearchRecipe;
using Recipe.Application.UseCases.RecipeUseCases.UpdateRecipe;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recipe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : BaseApiController
    {
        public RecipeController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new SearchRecipeQuery();

            try
            {
                return Ok(Mediator.Send(query).Result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<RecipeDto>> Get(string id)
        {
            var query = new SearchRecipeQuery();
            query.Keyword = id;

            try
            {
                return Ok(Mediator.Send(query).Result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddRecipeUseCase model)
        {
            try
            {
                await Mediator.Send(model);

                return Ok();
            }
            catch (EntityAlreadyExistsException e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateRecipeRequest model)
        {
            try
            {
                model.Id = id;
                await Mediator.Send(model);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var model = new DeleteRecipeRequest();
                model.Id = id;
                await Mediator.Send(model);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}