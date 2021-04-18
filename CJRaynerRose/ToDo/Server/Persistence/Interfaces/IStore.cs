using System.Collections.Generic;
using CJRaynerRose.ToDo.Common.Master;

namespace CJRaynerRose.ToDo.Server.Persistence.Interfaces
{
    public interface IStore<T>
    {
        public void Add(T entity);
        public ICollection<T> GetAll();
        public void Update(T entity);
    }
}