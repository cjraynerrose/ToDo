using System;
using CJRaynerRose.ToDo.Server.UseCases.Interfaces;

namespace CJRaynerRose.ToDo.Server.UseCases.Master
{
    public class CreateItemCommand : ICommand
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public bool Complete { get; init; } = false;
    }
}