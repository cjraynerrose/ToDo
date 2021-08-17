using System;
using System.Threading.Tasks;
using CJRaynerRose.ToDo.Common.Context;
using CJRaynerRose.ToDo.Common.Main;
using CJRaynerRose.ToDo.Server.Api.Main;
using CJRaynerRose.ToDo.Server.Persistence.InMemory.Main;
using CJRaynerRose.ToDo.Server.UseCases.Main;
using CJRaynerRose.ToDo.Server.UseCases.Store;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace CJRaynerRose.ToDo.Tests
{
    public class ApiControllerTests
    {
        private ToDoApiController controller;
        private IInteractionContext context;
        private IStore<Item> store;

        [SetUp]
        public void SetUp()
        {
            controller = new ToDoApiController();
            context = new InteractionContext();
            store = new ItemInMemStore(context);
        }

        [Test]
        public async Task CreateNewItem_WhenValid()
        {
            // Arrange
            CreateItemCommandHandler handler = new(store);
            CreateItemCommand command = new()
            {
                Id = new Guid(),
                Name = "Test",
                Complete = false
            };

            // Act
            IActionResult result = await controller.CreateItem(context, handler, command);

            // Assert

        }
    }
}