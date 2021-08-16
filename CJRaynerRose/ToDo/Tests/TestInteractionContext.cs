using System;
using CJRaynerRose.ToDo.Common.Context;

namespace CJRaynerRose.ToDo.Tests
{
    public class TestInteractionContext : IInteractionContext
    {
        public Guid GetContextId()
        {
            return Guid.Empty;
        }

    }
}