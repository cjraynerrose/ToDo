using System;

namespace CJRaynerRose.ToDo.Common.Events
{
    public interface IEventStore
    {
        IEvent Get(Guid id);
        void Push(IEvent e);
    }
}