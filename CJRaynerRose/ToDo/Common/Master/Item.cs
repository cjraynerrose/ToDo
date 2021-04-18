using System;
using CJRaynerRose.ToDo.Common.Base;

namespace CJRaynerRose.ToDo.Common.Master
{
    public class Item : IIdentifiable<Guid>
    {
        public Guid Id { private get; init; }
        public string Name { get; init; }
        public bool Complete { get; init; }
        public Guid GetId()
        {
            return Id;
        }
    }
}
