using CJRaynerRose.ToDo.Common.Context;
using CJRaynerRose.ToDo.Common.Events;

namespace CJRaynerRose.ToDo.Server.Context
{
    public class InteractionContext : IInteractionContext
    {
        readonly private IEventStore _store;

        public InteractionContext(IEventStore store)
        {
            _store = store;
        }

        public void PushEventToStore(IEvent e)
        {
            _store.Push(e);
        }
    }
}