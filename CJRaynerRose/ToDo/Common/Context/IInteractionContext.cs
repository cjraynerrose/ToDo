using CJRaynerRose.ToDo.Common.Events;

namespace CJRaynerRose.ToDo.Common.Context
{
    public interface IInteractionContext
    {
        void PushEventToStore(IEvent e);
    }
}