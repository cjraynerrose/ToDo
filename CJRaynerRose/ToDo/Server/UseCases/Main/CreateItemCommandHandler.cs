using System.Text.Json;
using CJRaynerRose.ToDo.Common.Context;
using CJRaynerRose.ToDo.Common.Events;
using CJRaynerRose.ToDo.Common.Main;
using CJRaynerRose.ToDo.Server.UseCases.Interfaces;
using CJRaynerRose.ToDo.Server.UseCases.Store;

namespace CJRaynerRose.ToDo.Server.UseCases.Main
{
    public class CreateItemCommandHandler : ICommandHandler<CreateItemCommand>
    {
        readonly private IStore<Item> _store;

        public CreateItemCommandHandler(IStore<Item> store)
        {
            _store = store;
        }

        public void Execute(CreateItemCommand command, IInteractionContext context)
        {
            context.RaiseEvent($"Executing {command.GetType().FullName}: {JsonSerializer.Serialize(command)}",
                State.Started);

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