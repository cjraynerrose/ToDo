using CJRaynerRose.ToDo.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CJRaynerRose.ToDo.Common.Context
{
    public class InteractionContext : IInteractionContext, IHasResult<object>
    {
        private readonly Guid _concurrencyId;
        public Dictionary<string, object> Values;

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

        public object GetResult()
        {
            return Values.Keys.First(k => k == Keys.Result);
        }

        public class Keys
        {
            public const string Result = "_RESULT_";
        }
    }
}