using System;
using System.Collections.Generic;
using System.Linq;
using CJRaynerRose.ToDo.Common.Events;

namespace CJRaynerRose.ToDo.Tests.Events
{
    internal class TestEventStore : IEventStore
    {
        readonly private List<IEvent> _events;

        public TestEventStore()
        {
            _events = new List<IEvent>();
        }

        public IEvent Get(Guid id)
        {
            return _events.FirstOrDefault(e => e.GetId() == id);
        }

        public EventChain GetEventsForContextOrderedByTime(Guid concurrencyId)
        {
            throw new NotImplementedException();
        }

        public void Push(IEvent e)
        {
            _events.Add(e);
        }
    }
}