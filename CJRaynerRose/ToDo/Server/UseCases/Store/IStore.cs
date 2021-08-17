using System.Collections.Generic;

namespace CJRaynerRose.ToDo.Server.UseCases.Store
{
    public interface IStore<T>
    {
        public void Add(T entity);
        public ICollection<T> GetAll();
        public void Update(T entity);
        public void Remove(T entity);
    }
}