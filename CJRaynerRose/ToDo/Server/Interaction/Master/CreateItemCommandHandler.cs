using CJRaynerRose.ToDo.Common.Master;
using CJRaynerRose.ToDo.Server.Interaction.Interfaces;
using CJRaynerRose.ToDo.Server.Persistence.Interfaces;

namespace CJRaynerRose.ToDo.Server.Interaction.Master
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