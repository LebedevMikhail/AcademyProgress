using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProgressAcademy.Application.Commands.Theme;
using ProgressAcademy.Application.Queries.Theme;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.ReadModels;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Handlers.Commands.Theme.Tests
{
    [TestClass]
    public class ThemeCommandHandlerTests
    {
        private Mock<IThemeRepository> _mockThemeRepository;
        private ThemeCommandHandler _themeCommandHandler;

        [TestInitialize]
        public void Initialize()
        {
            _mockThemeRepository = new Mock<IThemeRepository>();
            _themeCommandHandler = new ThemeCommandHandler(_mockThemeRepository.Object);
        }

        [TestMethod]
        public async Task Handle_CreateThemeCommand_ShouldCreateTheme()
        {
            var command = new CreateThemeCommand
            {
                Title = "Test Theme",
                Questions = new List<IQuestionAnswer>()
            };

            await _themeCommandHandler.Handle(command, CancellationToken.None);

            _mockThemeRepository.Verify(repo => repo.CreateThemeAsync(It.IsAny<Domain.Models.Theme>(), CancellationToken.None), Times.Once);
        }

        [TestMethod]
        public async Task Handle_UpdateThemeCommand_ShouldUpdateTheme()
        {
            var command = new UpdateThemeCommand
            {
                ThemeId = 1,
                Title = "Updated Test Theme",
                Questions = new List<IQuestionAnswer>()
            };

            await _themeCommandHandler.Handle(command, CancellationToken.None);

            _mockThemeRepository.Verify(repo => repo.UpdateThemeAsync(It.IsAny<Domain.Models.Theme>(), CancellationToken.None), Times.Once);
        }

        [TestMethod]
        public async Task Handle_DeleteThemeCommand_ShouldDeleteTheme()
        {
            var command = new DeleteThemeCommand
            {
                ThemeId = 1
            };

            await _themeCommandHandler.Handle(command, CancellationToken.None);

            _mockThemeRepository.Verify(repo => repo.DeleteThemeAsync(It.IsAny<int>(), CancellationToken.None), Times.Once);
        }

        [TestMethod]
        public async Task Handle_CreateThemeCommand_NullCommand_ShouldThrowArgumentNullException()
        {
            CreateThemeCommand command = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _themeCommandHandler.Handle(command, CancellationToken.None));
        }

        [TestMethod]
        public async Task Handle_UpdateThemeCommand_NullCommand_ShouldThrowArgumentNullException()
        {
            UpdateThemeCommand command = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _themeCommandHandler.Handle(command, CancellationToken.None));
        }

        [TestMethod]
        public async Task Handle_DeleteThemeCommand_NullCommand_ShouldThrowArgumentNullException()
        {
            DeleteThemeCommand command = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _themeCommandHandler.Handle(command, CancellationToken.None));
        }
    }
}
