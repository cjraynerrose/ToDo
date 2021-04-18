using System;
using System.Data;
using CJRaynerRose.ToDo.Common.Events;
using CJRaynerRose.ToDo.Common.Util.Time;

namespace CJRaynerRose.ToDo.Server.Events
{
    public class ServerEvent : IEvent
    {
        public ServerEvent(string description, string state)
        {
            Id = Guid.NewGuid();
            Timestamp = SystemTime.Now;
            Description = description;
            State = state;
        }

        private Guid Id { get; }
        private DateTime Timestamp { get; }
        private string Description { get; }
        private string State { get; }

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

        public string GetState()
        {
            return State;
        }
    }
}