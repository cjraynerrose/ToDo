using System;
using CJRaynerRose.ToDo.Common.Context;
using CJRaynerRose.ToDo.Common.Events;
using CJRaynerRose.ToDo.Server.Events;

namespace CJRaynerRose.ToDo.Server.Context
{
    public class InteractionContext : IInteractionContext
    {
        readonly private Guid _concurrencyId;
        readonly private IEventStore _store;

        public InteractionContext(IEventStore store, Guid? concurrencyId)
        {
            _concurrencyId = concurrencyId ?? Guid.NewGuid();
            _store = store;
        }

        public Guid GetContextId()
        {
            return _concurrencyId;
        }

        public void RaiseEvent(IEvent e)
        {
            _store.Push(e);
        }

        public void RaiseEvent(string description, State state)
        {
            IEvent e = new ServerEvent(_concurrencyId, description, state);
            RaiseEvent(e);
        }
    }
}