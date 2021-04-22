using System;
using CJRaynerRose.ToDo.Common.Base;

namespace CJRaynerRose.ToDo.Common.Events
{
    public interface IEvent : IIdentifiable<Guid>
    {
        Guid GetEventContext();
        DateTime GetWhenEmitted();
        string GetDescription();
        string GetState();
    }
}