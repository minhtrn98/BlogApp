using BlogApp.Application.Commands;
using BlogApp.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Api.Controllers
{
    public class CategoryController : BlogAppControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Mediator is null
                ? BadRequest()
                : Ok(await Mediator.Send(new GetCategoriesQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            return Mediator is null
                ? BadRequest()
                : Ok(await Mediator.Send(command));
        }
    }
}
