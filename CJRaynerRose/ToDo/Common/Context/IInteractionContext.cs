using System;
using CJRaynerRose.ToDo.Common.Events;

namespace CJRaynerRose.ToDo.Common.Context
{
    public interface IInteractionContext
    {
        Guid GetContextId();
        void RaiseEvent(IEvent e);
        void RaiseEvent(string description, string state);
    }
}