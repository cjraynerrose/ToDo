using System;
using System.Collections.Generic;
using CJRaynerRose.ToDo.Common.Context;
using CJRaynerRose.ToDo.Common.Events;
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
                _context.RaiseEvent($"Cannot add item to store, key already exists: {item.GetId()}", State.Failure);
                return;
            }

            AddOrUpdate(item);
            _context.RaiseEvent($"Item added: {item.GetId()}", State.Complete);
        }

        public ICollection<Item> GetAll()
        {
            return _items.Values;
        }

        public void Update(Item item)
        {
            if (!_items.ContainsKey(item.GetId()))
            {
                _context.RaiseEvent($"Cannot update item in store, key does not exist: {item.GetId()}", State.Failure);
                return;
            }

            AddOrUpdate(item);
            _context.RaiseEvent($"Item updated: {item.GetId()}", State.Complete);
        }

        private void AddOrUpdate(Item item)
        {
            _items[item.GetId()] = item;
        }
    }
}