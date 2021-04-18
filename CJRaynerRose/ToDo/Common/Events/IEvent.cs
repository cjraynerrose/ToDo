using System;
using CJRaynerRose.ToDo.Common.Base;

namespace CJRaynerRose.ToDo.Common.Events
{
    public interface IEvent : IIdentifiable<Guid>
    {
        DateTime GetWhenEmitted();
        string GetDescription();
        string GetState();
    }
}