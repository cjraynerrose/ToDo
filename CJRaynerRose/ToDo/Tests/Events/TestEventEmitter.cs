using CJRaynerRose.ToDo.Common.Events;

namespace CJRaynerRose.ToDo.Tests.Events
{
    internal class TestEventEmitter
    {
        private IEventStore _eventStore;

        public TestEventEmitter(TestEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public void Emit(IEvent e)
        {
            _eventStore.Push(e);
        }
    }
}