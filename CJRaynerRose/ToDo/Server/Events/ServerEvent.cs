using System;
using CJRaynerRose.ToDo.Common.Events;
using CJRaynerRose.ToDo.Common.Util.Time;

namespace CJRaynerRose.ToDo.Server.Events
{
    public class ServerEvent : IEvent
    {
        public ServerEvent(Guid concurrencyId, string description, State state)
        {
            Id = Guid.NewGuid();
            ConcurrencyId = concurrencyId;
            Timestamp = SystemTime.Now;
            Description = description;
            State = state;
        }

        private Guid Id { get; }
        private Guid ConcurrencyId { get; }
        private DateTime Timestamp { get; }
        private string Description { get; }
        private State State { get; }

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
            return ConcurrencyId;
        }
    }
}