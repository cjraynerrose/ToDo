using System.Threading.Tasks;
using CJRaynerRose.ToDo.Common.Context;
using CJRaynerRose.ToDo.Server.UseCases.Main;
using Microsoft.AspNetCore.Mvc;

namespace CJRaynerRose.ToDo.Server.Api.Main
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ToDoApiController : ControllerBase
    {
        [HttpPost]
        async public Task<IActionResult> CreateItem(
            [FromServices] IInteractionContext context,
            [FromServices] CreateItemCommandHandler handler,
            CreateItemCommand createItemCommand)
        {
            await Task.Run(() => handler.Execute(createItemCommand, context));
            return null;
        }
    }
}