using System;
using System.Collections.Generic;
using System.Linq;
using CJRaynerRose.ToDo.Common.Master;
using CJRaynerRose.ToDo.Server.Persistence.Master;
using CJRaynerRose.ToDo.Server.UseCases.Master;
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
            CreateItemCommand createItemCommand = new ()
            {
                Id = Guid.NewGuid(),
                Name = "New Item"
            };

            CreateItemCommandHandler commandHandler = new (new TestInteractionContext(), _store);

            //Act
            commandHandler.Execute(createItemCommand);

            //Assert
            Assert.That(_store.GetAll().Count, Is.EqualTo(1));
        }

        [Test]
        public void FailCreateItem_WhenIdExists()
        {
            //Arrange
            Guid id = Guid.NewGuid();

            _store.Add(new Item()
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

            CreateItemCommandHandler commandHandler = new(new TestInteractionContext(), _store);

            //Act
            commandHandler.Execute(createItemCommand);

            //Assert
            ICollection<Item> items = _store.GetAll();
            Assert.That(items.Count, Is.EqualTo(1));
            Assert.That(items.First().Name, Is.EqualTo("Existing Item"));
        }
    }
}
