using System.Text.Json;
using System.Text.Json.Serialization;
using CJRaynerRose.ToDo.Common.Context;
using CJRaynerRose.ToDo.Common.Master;
using CJRaynerRose.ToDo.Server.Events;
using CJRaynerRose.ToDo.Server.UseCases.Interfaces;
using CJRaynerRose.ToDo.Server.UseCases.Store;

namespace CJRaynerRose.ToDo.Server.UseCases.Master
{
    public class CreateItemCommandHandler : ICommandHandler<CreateItemCommand>
    {
        readonly private IInteractionContext _context;
        readonly private IStore<Item> _store;

        public CreateItemCommandHandler(IInteractionContext context, IStore<Item> store)
        {
            _context = context;
            _store = store;
        }

        public void Execute(CreateItemCommand command)
        {
            _context.RaiseEvent($"Executing {command.GetType().FullName}: {JsonSerializer.Serialize(command)}", State.STARTED);

            Item newItem = new()
            {
                Id = command.Id,
                Name = command.Name,
                Complete = command.Complete
            };


            _store.Add(newItem);
        }
    }
}