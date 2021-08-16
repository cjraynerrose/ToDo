using System;
using System.Collections.Generic;
using System.Linq;
using CJRaynerRose.ToDo.Common.Main;
using CJRaynerRose.ToDo.Server.Persistence.InMemory.Main;
using CJRaynerRose.ToDo.Server.UseCases.Store;
using NUnit.Framework;

namespace CJRaynerRose.ToDo.Tests
{
    public class Persistence
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddNewItem_WhenValid()
        {
            // Arrange
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Complete = false
            };

            IStore<Item> store = new ItemInMemStore(new TestInteractionContext());

            //Act
            store.Add(item);

            //Assert
            ICollection<Item> storeItems = store.GetAll();
            Assert.That(storeItems, Has.Count.EqualTo(1));
        }

        [Test]
        public void UpdateItem_WhenValid()
        {
            // Arrange
            var id = Guid.NewGuid();

            Item item = new()
            {
                Id = id,
                Name = "Test",
                Complete = false
            };

            IStore<Item> store = new ItemInMemStore(new TestInteractionContext());
            store.Add(item);

            //Act
            store.Update(new Item
            {
                Id = id,
                Name = "Test",
                Complete = true
            });

            //Assert
            ICollection<Item> storeItems = store.GetAll();
            Assert.That(storeItems.First().Complete, Is.EqualTo(true));
        }
    }
}