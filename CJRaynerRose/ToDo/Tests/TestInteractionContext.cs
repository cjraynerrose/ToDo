using System;
using CJRaynerRose.ToDo.Common.Context;
using CJRaynerRose.ToDo.Common.Events;

namespace CJRaynerRose.ToDo.Tests
{
    public class TestInteractionContext : IInteractionContext
    {
        public Guid GetContextId()
        {
            return Guid.Empty;
        }

        public void RaiseEvent(IEvent e)
        {
            return;
        }

        public void RaiseEvent(string description, string state)
        {
            return;
        }
    }
}