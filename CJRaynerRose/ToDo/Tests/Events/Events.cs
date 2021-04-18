using System;
using CJRaynerRose.ToDo.Common.Events;
using CJRaynerRose.ToDo.Common.Master;
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
            Guid id = Guid.NewGuid();
            TestEvent testEvent = new TestEvent()
            {
                Id = id,
                Description = "This is a test event",
                State = "TEST",
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