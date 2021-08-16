using System;
using CJRaynerRose.ToDo.Common.Context;
using CJRaynerRose.ToDo.Common.Events;
using CJRaynerRose.ToDo.Common.Main;
using CJRaynerRose.ToDo.Server.Context;
using CJRaynerRose.ToDo.Server.Events;
using CJRaynerRose.ToDo.Server.Persistence.InMemory.Main;
using CJRaynerRose.ToDo.Server.UseCases.Main;
using CJRaynerRose.ToDo.Server.UseCases.Store;
using NUnit.Framework;

namespace CJRaynerRose.ToDo.Tests.Events
{
    public class EventChainTests
    {
        private IInteractionContext _context;
        private Guid _contextId;
        private IEventStore _eventStore;
        private IStore<Item> _store;

        [SetUp]
        public void SetUp()
        {
            _eventStore = new InMemEventStore();
            _contextId = Guid.NewGuid();
            _context = new InteractionContext(_eventStore, _contextId);
            _store = new ItemInMemStore(_context);
        }

        [Test]
        public void EventChainRecorded_WhenCommandIssued()
        {
            //Arrange
            CreateItemCommand command = new()
            {
                Id = Guid.NewGuid(),
                Name = "Must Remember to Test Events",
                Complete = false
            };

            CreateItemCommandHandler handler = new(_store);

            handler.Execute(command, _context);

            // Act
            EventChain eventChain = _eventStore.GetEventsForContextOrderedByTime(_contextId);
            Console.WriteLine(eventChain);

            Assert.That(eventChain.GetEvents(), Has.Count.EqualTo(2));
        }
    }
}