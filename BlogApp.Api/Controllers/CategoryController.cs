using BlogApp.Application.Commands;
using BlogApp.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Api.Controllers
{
    public class CategoryController : BlogAppControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken cancellation)
        {
            return Ok(await Mediator.Send(new GetCategoriesQuery(), cancellation));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
