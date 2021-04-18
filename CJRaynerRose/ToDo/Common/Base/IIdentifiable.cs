namespace CJRaynerRose.ToDo.Common.Base
{
    public interface IIdentifiable<TKey>
    {
        TKey GetId();
    }
}