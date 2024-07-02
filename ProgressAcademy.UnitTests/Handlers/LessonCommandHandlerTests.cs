using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProgressAcademy.Application.Commands.Lesson;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Handlers.Commands.Tests
{
    [TestClass]
    public class LessonCommandHandlerTests
    {
        [TestMethod]
        public async Task Handle_CreateLessonCommand_ValidCommand_CallsCreateLessonAsync()
        {
            var mockRepository = new Mock<ILessonRepository>();
            var handler = new LessonCommandHandler(mockRepository.Object);
            var command = new CreateLessonCommand { Lesson = new Lesson() };

            await handler.Handle(command, CancellationToken.None);

            mockRepository.Verify(repo => repo.CreateLessonAsync(It.IsAny<Lesson>(), CancellationToken.None), Times.Once);
        }

        [TestMethod]
        public async Task Handle_UpdateLessonCommand_ValidCommand_CallsUpdateLessonAsync()
        {
            var mockRepository = new Mock<ILessonRepository>();
            var handler = new LessonCommandHandler(mockRepository.Object);
            var command = new UpdateLessonCommand { Lesson = new Lesson() };

            await handler.Handle(command, CancellationToken.None);

            mockRepository.Verify(repo => repo.UpdateLessonAsync(It.IsAny<Lesson>(), CancellationToken.None), Times.Once);
        }

        [TestMethod]
        public async Task Handle_DeleteLessonCommand_ValidCommand_CallsDeleteLessonAsync()
        {
            var mockRepository = new Mock<ILessonRepository>();
            var handler = new LessonCommandHandler(mockRepository.Object);
            var command = new DeleteLessonCommand { LessonId = 1 };

            await handler.Handle(command, CancellationToken.None);

            mockRepository.Verify(repo => repo.DeleteLessonAsync(It.IsAny<int>(), CancellationToken.None), Times.Once);
        }

        [TestMethod]
        public async Task Handle_CreateLessonCommand_NullCommand_ThrowsArgumentNullException()
        {
            var mockRepository = new Mock<ILessonRepository>();
            var handler = new LessonCommandHandler(mockRepository.Object);
            CreateLessonCommand command = null;
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => handler.Handle(command, CancellationToken.None));
        }

        [TestMethod]
        public async Task Handle_UpdateLessonCommand_NullCommand_ThrowsArgumentNullException()
        {
            var mockRepository = new Mock<ILessonRepository>();
            var handler = new LessonCommandHandler(mockRepository.Object);
            UpdateLessonCommand command = null;
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => handler.Handle(command, CancellationToken.None));
        }

        [TestMethod]
        public async Task Handle_DeleteLessonCommand_NullCommand_ThrowsArgumentNullException()
        {
            var mockRepository = new Mock<ILessonRepository>();
            var handler = new LessonCommandHandler(mockRepository.Object);
            DeleteLessonCommand command = null;
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => handler.Handle(command, CancellationToken.None));
        }
    }
}
