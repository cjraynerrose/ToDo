using System;
using CJRaynerRose.ToDo.Common.Events;

namespace CJRaynerRose.ToDo.Tests.Events
{
    internal class TestEvent : IEvent
    {
        public Guid Id { get; init; }
        public string Description { get; init; }
        public State State { get; init; }
        public DateTime Timestamp { get; init; }

        public Guid GetId()
        {
            return Id;
        }

        public DateTime GetWhenEmitted()
        {
            return Timestamp;
        }

        public string GetDescription()
        {
            return Description;
        }

        public State GetState()
        {
            return State;
        }

        public Guid GetEventConcurrencyId()
        {
            throw new NotImplementedException();
        }
    }
}