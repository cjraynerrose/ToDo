using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CJRaynerRose.ToDo.Common.Events
{
    public class EventChain
    {
        readonly private IEnumerable<IEvent> _events;

        public EventChain(IEnumerable<IEvent> events)
        {
            _events = events.OrderBy(e => e.GetWhenEmitted());
        }

        public IReadOnlyCollection<IEvent> GetEvents()
        {
            return _events.ToList();
        }

        override public string ToString()
        {
            StringBuilder sb = new();

            foreach (IEvent e in _events)
                sb.AppendLine($"{e.GetWhenEmitted()} :: {e.GetState()} : {e.GetDescription()}");

            return sb.ToString();
        }
    }
}