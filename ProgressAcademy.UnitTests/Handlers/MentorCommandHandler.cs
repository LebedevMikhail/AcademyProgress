using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProgressAcademy.Handlers.Commands;
using ProgressAcademy.Application.Commands.Mentor;
using ProgressAcademy.Domain.Repositories;
using ProgressAcademy.Domain.Models;

namespace ProgressAcademy.Tests.Handlers.Commands
{
    [TestClass]
    public class MentorCommandHandlerTests
    {
        private Mock<IMentorRepository> _mockMentorRepository;
        private MentorCommandHandler _mentorCommandHandler;

        [TestInitialize]
        public void Setup()
        {
            _mockMentorRepository = new Mock<IMentorRepository>();
            _mentorCommandHandler = new MentorCommandHandler(_mockMentorRepository.Object);
        }

        [TestMethod]
        public async Task Handle_CreateMentorCommand_Success()
        {
            var command = new CreateMentorCommand { Mentor = new Mentor() };

            await _mentorCommandHandler.Handle(command, CancellationToken.None);

            _mockMentorRepository.Verify(repo => repo.CreateMentorAsync(command.Mentor, CancellationToken.None), Times.Once);
        }

        [TestMethod]
        public async Task Handle_CreateMentorCommand_NullCommand_ThrowsException()
        {
            CreateMentorCommand command = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _mentorCommandHandler.Handle(command, CancellationToken.None));
        }

        [TestMethod]
        public async Task Handle_UpdateMentorCommand_Success()
        {
            var command = new UpdateMentorCommand { Mentor = new Mentor() };

            await _mentorCommandHandler.Handle(command, CancellationToken.None);

            _mockMentorRepository.Verify(repo => repo.UpdateMentorAsync(command.Mentor, CancellationToken.None), Times.Once);
        }

        [TestMethod]
        public async Task Handle_UpdateMentorCommand_NullCommand_ThrowsException()
        {
            UpdateMentorCommand command = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _mentorCommandHandler.Handle(command, CancellationToken.None));
        }

        [TestMethod]
        public async Task Handle_DeleteMentorCommand_Success()
        {
            var command = new DeleteMentorCommand { MentorId = 1 };

            await _mentorCommandHandler.Handle(command, CancellationToken.None);

            _mockMentorRepository.Verify(repo => repo.DeleteMentorAsync(command.MentorId, CancellationToken.None), Times.Once);
        }

        [TestMethod]
        public async Task Handle_DeleteMentorCommand_NullCommand_ThrowsException()
        {
            DeleteMentorCommand command = null;

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _mentorCommandHandler.Handle(command, CancellationToken.None));
        }
    }
}
