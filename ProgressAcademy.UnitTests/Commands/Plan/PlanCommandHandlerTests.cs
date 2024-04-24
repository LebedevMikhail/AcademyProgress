using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProgressAcademy.Application.Commands.Plan;
using ProgressAcademy.Domain.Repositories;
using ProgressAcademy.Handlers.Commands;

namespace ProgressAcademy.UnitTests.Commands.Plan
{
    [TestClass]
    public class PlanCommandHandlerTests
    {
        private Mock<IPlanRepository>? _planRepository;
        private PlanCommandHandler? _handler;

        [TestMethod]
        public async Task Handle_CreatePlanCommand_WithNullPlan_ThrowsArgumentNullException()
        {
            _planRepository = new Mock<IPlanRepository>();
            _handler = new PlanCommandHandler(_planRepository.Object);

            var createPlanCommand = new CreatePlanCommand { Plan = null };
            var cancellationTokenSource = new CancellationTokenSource();
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await _handler.Handle(createPlanCommand, cancellationTokenSource.Token));
        }

        [TestMethod]
        public async Task Handle_UpdatePlanCommand_WithNullPlan_ThrowsArgumentNullException()
        {
            _planRepository = new Mock<IPlanRepository>();
            _handler = new PlanCommandHandler(_planRepository.Object);
            var updatePlanCommand = new UpdatePlanCommand { Plan = null };
            var cancellationTokenSource = new CancellationTokenSource();

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await _handler.Handle(updatePlanCommand, cancellationTokenSource.Token));
        }

        [TestMethod]
        public async Task Handle_DeletePlanCommand_WithZeroPlanId_ThrowsArgumentNullException()
        {
            _planRepository = new Mock<IPlanRepository>();
            _handler = new PlanCommandHandler(_planRepository.Object);
            var deletePlanCommand = new DeletePlanCommand { PlanId = 0 };
            var cancellationTokenSource = new CancellationTokenSource();

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await _handler.Handle(deletePlanCommand, cancellationTokenSource.Token));
        }

        [TestMethod]
        public async Task Handle_CreatePlanCommand_CallsCreatePlanMethodInRepository()
        {
            _planRepository = new Mock<IPlanRepository>();
            _handler = new PlanCommandHandler(_planRepository.Object);
            var createPlanCommand = new CreatePlanCommand { Plan = new Domain.Models.Plan() };
            var cancellationTokenSource = new CancellationTokenSource();

            await _handler.Handle(createPlanCommand, cancellationTokenSource.Token);

            _planRepository.Verify(x => x.CreatePlanAsync(It.IsAny<Domain.Models.Plan>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        public async Task Handle_UpdatePlanCommand_CallsUpdatePlanMethodInRepository()
        {
            _planRepository = new Mock<IPlanRepository>();
            _handler = new PlanCommandHandler(_planRepository.Object);
            var updatePlanCommand = new UpdatePlanCommand { Plan = new Domain.Models.Plan() };
            var cancellationTokenSource = new CancellationTokenSource();
            await _handler.Handle(updatePlanCommand, cancellationTokenSource.Token);

            _planRepository.Verify(x => x.UpdatePlanAsync(It.IsAny<Domain.Models.Plan>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestMethod]
        public async Task Handle_DeletePlanCommand_CallsDeletePlanMethodInRepository()
        {
            _planRepository = new Mock<IPlanRepository>();
            _handler = new PlanCommandHandler(_planRepository.Object);
            var deletePlanCommand = new DeletePlanCommand { PlanId = 0 };
            var cancellationTokenSource = new CancellationTokenSource();
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () =>
                {
                    await _handler.Handle(deletePlanCommand, cancellationTokenSource.Token);
                });
        }
    }
}