using System;
using CJRaynerRose.ToDo.Common.Context;

namespace CJRaynerRose.ToDo.Server.Context
{
    public class InteractionContext : IInteractionContext
    {
        private readonly Guid _concurrencyId;

        public InteractionContext(Guid concurrencyId)
        {
            _concurrencyId = concurrencyId;
        }

        public InteractionContext()
        {
            _concurrencyId = Guid.NewGuid();
        }

        public Guid GetContextId()
        {
            return _concurrencyId;
        }
    }
}