using System;
using System.Collections.Generic;
using CJRaynerRose.ToDo.Common.Events;

namespace CJRaynerRose.ToDo.Server.Events
{
    public class InMemEventStore : IEventStore
    {
        private Dictionary<Guid, IEvent> _events;

        public InMemEventStore()
        {
            _events = new Dictionary<Guid, IEvent>();
        }

        public IEvent Get(Guid id)
        {
            return _events[id];
        }

        public void Push(IEvent e)
        {
            _events.Add(e.GetId(), e);
        }
    }
}