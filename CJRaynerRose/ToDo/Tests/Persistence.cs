using System;
using System.Linq;
using CJRaynerRose.ToDo.Common.Master;
using CJRaynerRose.ToDo.Server.Persistence.Interfaces;
using CJRaynerRose.ToDo.Server.Persistence.Master;
using NUnit.Framework;
using NUnit.Framework.Constraints;

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

            IStore<Item> store = new ItemInMemStore();

            //Act
            store.Add(item);

            //Assert
            var storeItems = store.GetAll();
            Assert.That(storeItems, Has.Count.EqualTo(1));
        }

        [Test]
        public void UpdateItem_WhenValid()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            Item item = new()
            {
                Id = id,
                Name = "Test",
                Complete = false
            };

            IStore<Item> store = new ItemInMemStore();
            store.Add(item);

            //Act
            store.Update(new Item()
            {
                Id = id,
                Name = "Test",
                Complete = true
            });

            //Assert
            var storeItems = store.GetAll();
            Assert.That(storeItems.First().Complete, Is.EqualTo(true));
        }
    }
}