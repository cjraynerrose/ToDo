using CJRaynerRose.ToDo.Common.Master;
using CJRaynerRose.ToDo.Server.Context;
using CJRaynerRose.ToDo.Server.UseCases.Store;
using System;
using System.Collections.Generic;
using CJRaynerRose.ToDo.Common.Context;
using CJRaynerRose.ToDo.Server.Events;

namespace CJRaynerRose.ToDo.Server.Persistence.Master
{
    public class ItemInMemStore : IStore<Item>
    {
        private IDictionary<Guid, Item> _items;
        readonly private IInteractionContext _context;


        public ItemInMemStore(IInteractionContext context)
        {
            _context = context;
            _items = new Dictionary<Guid, Item>();
        }

        public void Add(Item item)
        {
            if (_items.ContainsKey(item.GetId()))
            {
                _context.RaiseEvent($"Cannot add item to store, key already exists: {item.GetId()}", State.FAILURE);
                return;
            }
            AddOrUpdate(item);
            _context.RaiseEvent($"Item added: {item.GetId()}", State.COMPLETE);
        }

        public ICollection<Item> GetAll()
        {
            return _items.Values;
        }

        public void Update(Item item)
        {
            if (!_items.ContainsKey(item.GetId()))
            {
                _context.RaiseEvent($"Cannot update item in store, key does not exist: {item.GetId()}", State.FAILURE);
                return;
            }
            AddOrUpdate(item);
            _context.RaiseEvent($"Item updated: {item.GetId()}", State.COMPLETE);
        }

        private void AddOrUpdate(Item item)
        {
            _items[item.GetId()] = item;
        }
    }
}
