using System;
using CJRaynerRose.ToDo.Server.Interaction.Interfaces;

namespace CJRaynerRose.ToDo.Server.Interaction.Master
{
    public class CreateItemCommand : ICommand
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
    }
}