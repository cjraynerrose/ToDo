using System.Threading.Tasks;
using CJRaynerRose.ToDo.Common.Context;
using CJRaynerRose.ToDo.Server.UseCases.Main;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CJRaynerRose.ToDo.Server.Api.Main
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ToDoApiController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateItem(
            [FromServices] IInteractionContext context,
            [FromServices] CreateItemCommandHandler handler,
            CreateItemCommand createItemCommand)
        {
            await Task.Run(() => handler.Execute(createItemCommand, context));
            return Ok();
        }

        //public async Task<IActionResult> GetItems(
        //    [FromServices] IInteractionContext context,
        //    [FromServices] GetItemsConnandHandler handler,
        //    GetItemsCommand getItemsCommand)
        //{
        //    var items = await Task.Run(() => handler.Execute(GetItemsCommand, context));
        //    return items;
        //}
    }
}