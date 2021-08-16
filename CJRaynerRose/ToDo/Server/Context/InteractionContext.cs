using System;
using CJRaynerRose.ToDo.Common.Context;

namespace CJRaynerRose.ToDo.Server.Context
{
    public class InteractionContext : IInteractionContext
    {
        readonly private Guid _concurrencyId;

        public InteractionContext(Guid? concurrencyId)
        {
            _concurrencyId = concurrencyId ?? Guid.NewGuid();
        }

        public Guid GetContextId()
        {
            return _concurrencyId;
        }
    }
}