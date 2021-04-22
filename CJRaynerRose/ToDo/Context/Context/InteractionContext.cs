using System;
using CJRaynerRose.ToDo.Common.Context;
using CJRaynerRose.ToDo.Common.Events;
using CJRaynerRose.ToDo.Server.Events;

namespace CJRaynerRose.ToDo.Server.Context
{
    public class InteractionContext : IInteractionContext
    {
        private readonly Guid _contextId;
        readonly private IEventStore _store;

        public InteractionContext(IEventStore store, Guid? contextId)
        {
            _contextId = contextId ?? Guid.NewGuid();
            _store = store;
        }

        public Guid GetContextId()
        {
            return _contextId;
        }

        public void RaiseEvent(IEvent e)
        {
            _store.Push(e);
        }

        public void RaiseEvent(string description, string state)
        {
            IEvent e = new ServerEvent(_contextId, description, state);
            RaiseEvent(e);
        }
    }
}