using System;
using System.Collections.Generic;

namespace CJRaynerRose.ToDo.Common.Events
{
    public interface IEventStore
    {
        IEvent Get(Guid id);
        EventChain GetEventsForContextOrderedByTime(Guid contextId);
        void Push(IEvent e);
    }
}