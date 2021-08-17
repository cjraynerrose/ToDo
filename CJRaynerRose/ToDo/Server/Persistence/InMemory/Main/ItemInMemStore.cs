using System;
using System.Collections.Generic;
using CJRaynerRose.ToDo.Common.Context;
using CJRaynerRose.ToDo.Common.Main;
using CJRaynerRose.ToDo.Server.UseCases.Store;

namespace CJRaynerRose.ToDo.Server.Persistence.InMemory.Main
{
    public class ItemInMemStore : IStore<Item>
    {
        readonly private IInteractionContext _context;
        readonly private IDictionary<Guid, Item> _items;


        public ItemInMemStore(IInteractionContext context)
        {
            _context = context;
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

        public void Remove(Item entity)
        {
            _items.Remove(entity.GetId());
        }

        public void Update(Item item)
        {
            if (!_items.ContainsKey(item.GetId()))
            {
                return;
            }

            AddOrUpdate(item);
        }

        private void AddOrUpdate(Item item)
        {
            _items[item.GetId()] = item;
        }
    }
}