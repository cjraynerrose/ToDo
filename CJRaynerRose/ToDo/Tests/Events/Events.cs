using System;
using CJRaynerRose.ToDo.Common.Events;
using NUnit.Framework;

namespace CJRaynerRose.ToDo.Tests.Events
{
    public class Events
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void ReadEvent_WhenEmitted()
        {
            //Arrange
            var id = Guid.NewGuid();
            var testEvent = new TestEvent
            {
                Id = id,
                Description = "This is a test event",
                State = State.Complete,
                Timestamp = DateTime.MaxValue
            };

            TestEventStore eventStore = new();
            TestEventEmitter emitter = new(eventStore);

            //Act
            emitter.Emit(testEvent);

            IEvent e = eventStore.Get(id);

            //Assert
            Assert.That(e, Is.EqualTo(testEvent));
        }
    }
}