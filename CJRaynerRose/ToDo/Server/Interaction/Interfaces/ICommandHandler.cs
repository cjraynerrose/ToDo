namespace CJRaynerRose.ToDo.Server.Interaction.Interfaces
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        public void Execute(T command);
    }
}