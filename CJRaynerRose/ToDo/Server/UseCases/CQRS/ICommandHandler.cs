namespace CJRaynerRose.ToDo.Server.UseCases.Interfaces
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        public void Execute(T command);
    }
}