using System;
using CJRaynerRose.ToDo.Common.Base;

namespace CJRaynerRose.ToDo.Common.Events
{
    public interface IEvent : IIdentifiable<Guid>
    {
        Guid GetEventConcurrencyId();
        DateTime GetWhenEmitted();
        string GetDescription();
        State GetState();
    }
}