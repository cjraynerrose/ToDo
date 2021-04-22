using System;
using System.Collections.Generic;
using System.Linq;
using CJRaynerRose.ToDo.Common.Events;

namespace CJRaynerRose.ToDo.Server.Events
{
    public class InMemEventStore : IEventStore
    {
        private HashSet<IEvent> _events;

        public InMemEventStore()
        {
            _events = new HashSet<IEvent>();
        }

        public IEvent Get(Guid id)
        {
            return _events.FirstOrDefault(e => e.GetId() == id);
        }

        public EventChain GetEventsForContextOrderedByTime(Guid contextId)
        {
            EventChain contextualEvents = new(
                _events
                    .Where(e => e.GetEventContext() == contextId)
                    .OrderBy(e => e.GetWhenEmitted()));

            return contextualEvents;
        }

        public void Push(IEvent e)
        {
            _events.Add(e);
        }
    }
}