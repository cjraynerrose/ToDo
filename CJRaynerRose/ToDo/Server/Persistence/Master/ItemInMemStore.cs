using System;
using System.Collections.Generic;
using CJRaynerRose.ToDo.Common.Master;
using CJRaynerRose.ToDo.Server.Persistence.Interfaces;

namespace CJRaynerRose.ToDo.Server.Persistence.Master
{
    public class ItemInMemStore : IStore<Item>
    {
        private IDictionary<Guid, Item> _items;

        public ItemInMemStore()
        {
            _items = new Dictionary<Guid, Item>();
        }

        public void Add(Item item)
        {
            if (_items.ContainsKey(item.GetId()))
            {
                return;
            }
            AddOrUpdate(item);
        }

        public ICollection<Item> GetAll()
        {
            return _items.Values;
        }

        public void Update(Item item)
        {
            AddOrUpdate(item);
        }

        private void AddOrUpdate(Item item)
        {
            _items[item.GetId()] = item;
        }
    }
}
