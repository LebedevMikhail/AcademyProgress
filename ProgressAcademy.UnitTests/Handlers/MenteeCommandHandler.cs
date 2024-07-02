using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using ProgressAcademy.Handlers.Commands;
using ProgressAcademy.Application.Commands.Mentee;
using ProgressAcademy.Domain.Repositories;
using ProgressAcademy.Domain.Models;

namespace ProgressAcademy.Tests.Handlers.Commands
{
    [TestClass]
    public class MenteeCommandHandlerTests
    {
        private Mock<IMenteeRepository> _mockMenteeRepository;
        private MenteeCommandHandler _menteeCommandHandler;

        [TestInitialize]
        public void Setup()
        {
            _mockMenteeRepository = new Mock<IMenteeRepository>();
            _menteeCommandHandler = new MenteeCommandHandler(_mockMenteeRepository.Object);
        }

        [TestMethod]
        public async Task Handle_CreateMenteeCommand_Success()
        {
            var command = new CreateMenteeCommand { Mentee = new Mentee() };

            await _menteeCommandHandler.Handle(command, CancellationToken.None);

            _mockMenteeRepository.Verify(repo => repo.CreateMenteeAsync(command.Mentee, CancellationToken.None), Times.Once);
        }

        [TestMethod]
        public async Task Handle_CreateMenteeCommand_NullCommand_ThrowsException()
        {
            CreateMenteeCommand command = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _menteeCommandHandler.Handle(command, CancellationToken.None));
        }

        [TestMethod]
        public async Task Handle_UpdateMenteeCommand_Success()
        {
            var command = new UpdateMenteeCommand { Mentee = new Mentee() };

            await _menteeCommandHandler.Handle(command, CancellationToken.None);

            _mockMenteeRepository.Verify(repo => repo.UpdateMenteeAsync(command.Mentee, CancellationToken.None), Times.Once);
        }

        [TestMethod]
        public async Task Handle_UpdateMenteeCommand_NullCommand_ThrowsException()
        {
            UpdateMenteeCommand command = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _menteeCommandHandler.Handle(command, CancellationToken.None));
        }

        [TestMethod]
        public async Task Handle_DeleteMenteeCommand_Success()
        {
            var command = new DeleteMenteeCommand { MenteeId = 1 };

            await _menteeCommandHandler.Handle(command, CancellationToken.None);

            _mockMenteeRepository.Verify(repo => repo.DeleteMenteeAsync(command.MenteeId, CancellationToken.None), Times.Once);
        }

        [TestMethod]
        public async Task Handle_DeleteMenteeCommand_NullCommand_ThrowsException()
        {
            DeleteMenteeCommand command = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _menteeCommandHandler.Handle(command, CancellationToken.None));
        }
    }
}
