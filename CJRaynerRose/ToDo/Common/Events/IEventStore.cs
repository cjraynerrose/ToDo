using System;

namespace CJRaynerRose.ToDo.Common.Events
{
    public interface IEventStore
    {
        IEvent Get(Guid id);
        EventChain GetEventsForContextOrderedByTime(Guid concurrencyId);
        void Push(IEvent e);
    }
}