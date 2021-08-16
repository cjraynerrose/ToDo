using System;
using System.Collections.Generic;
using System.Linq;
using CJRaynerRose.ToDo.Common.Main;
using CJRaynerRose.ToDo.Server.Persistence.InMemory.Main;
using CJRaynerRose.ToDo.Server.UseCases.Main;
using CJRaynerRose.ToDo.Server.UseCases.Store;
using NUnit.Framework;

namespace CJRaynerRose.ToDo.Tests
{
    public class Interaction
    {
        private IStore<Item> _store;

        [SetUp]
        public void SetUp()
        {
            _store = new ItemInMemStore(new TestInteractionContext());
        }

        [Test]
        public void CreateNewItem_WhenIdNotExist()
        {
            //Arrange
            CreateItemCommand createItemCommand = new()
            {
                Id = Guid.NewGuid(),
                Name = "New Item"
            };

            CreateItemCommandHandler commandHandler = new(_store);

            //Act
            commandHandler.Execute(createItemCommand, new TestInteractionContext());

            //Assert
            Assert.That(_store.GetAll().Count, Is.EqualTo(1));
        }

        [Test]
        public void FailCreateItem_WhenIdExists()
        {
            //Arrange
            var id = Guid.NewGuid();

            _store.Add(new Item
            {
                Id = id,
                Name = "Existing Item",
                Complete = false
            });

            CreateItemCommand createItemCommand = new()
            {
                Id = id,
                Name = "New Item"
            };

            CreateItemCommandHandler commandHandler = new(_store);

            //Act
            commandHandler.Execute(createItemCommand, new TestInteractionContext());

            //Assert
            ICollection<Item> items = _store.GetAll();
            Assert.That(items.Count, Is.EqualTo(1));
            Assert.That(items.First().Name, Is.EqualTo("Existing Item"));
        }
    }
}