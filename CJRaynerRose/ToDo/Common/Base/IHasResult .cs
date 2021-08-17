using System;

namespace CJRaynerRose.ToDo.Common.Base
{
    public interface IHasResult<TResult>
    {
        public TResult GetResult();
    }
}