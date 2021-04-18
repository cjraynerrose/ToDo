using CJRaynerRose.ToDo.Common.Master;
using CJRaynerRose.ToDo.Server.UseCases.Interfaces;
using CJRaynerRose.ToDo.Server.UseCases.Store;

namespace CJRaynerRose.ToDo.Server.UseCases.Master
{
    public class CreateItemCommandHandler : ICommandHandler<CreateItemCommand>
    {
        readonly private IStore<Item> _store;

        public CreateItemCommandHandler(IStore<Item> store)
        {
            _store = store;
        }

        public void Execute(CreateItemCommand command)
        {
            Item newItem = new()
            {
                Id = command.Id,
                Name = command.Name,
                Complete = false
            };

            _store.Add(newItem);
        }
    }
}