using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProgressAcademy.Application.Commands.Plan;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.Repositories;
using ProgressAcademy.Handlers.Commands;

[TestClass]
public class PlanCommandHandlerTests
{
    private IPlanRepository _planRepository;
    private PlanCommandHandler _handler;

    [TestInitialize]
    public void TestInitialize()
    {
        _planRepository = Mock.Of<IPlanRepository>();
        _handler = new PlanCommandHandler(_planRepository);
    }

    [TestMethod]
    public void Handle_CreatePlanCommand_WithNullPlan_ThrowsArgumentNullException()
    {
        // Arrange
        var createPlanCommand = new CreatePlanCommand { Plan = null };

        // Act + Assert
        Assert.ThrowsException<ArgumentNullException>(() => _handler.Handle(createPlanCommand));
    }

    [TestMethod]
    public void Handle_UpdatePlanCommand_WithNullPlan_ThrowsArgumentNullException()
    {
        // Arrange
        var updatePlanCommand = new UpdatePlanCommand { Plan = null };

        // Act + Assert
        Assert.ThrowsException<ArgumentNullException>(() => _handler.Handle(updatePlanCommand));
    }

    [TestMethod]
    public void Handle_DeletePlanCommand_WithZeroPlanId_ThrowsArgumentException()
    {
        // Arrange
        var deletePlanCommand = new DeletePlanCommand { PlanId = 0 };

        // Act + Assert
        Assert.ThrowsException<ArgumentException>(() => _handler.Handle(deletePlanCommand));
    }
    
    [TestMethod]
    public void Handle_CreatePlanCommand_CallsCreatePlanMethodInRepository()
    {
        // Arrange
        var createPlanCommand = new CreatePlanCommand { Plan = new Plan() };

        // Act
        _handler.Handle(createPlanCommand);

        // Assert
        Mock.Get(_planRepository).Verify(x => x.CreatePlan(It.IsAny<Plan>()), Times.Once);
    }

    [TestMethod]
    public void Handle_UpdatePlanCommand_CallsUpdatePlanMethodInRepository()
    {
        // Arrange
        var updatePlanCommand = new UpdatePlanCommand { Plan = new Plan() };

        // Act
        _handler.Handle(updatePlanCommand);

        // Assert
        Mock.Get(_planRepository).Verify(x => x.UpdatePlan(It.IsAny<Plan>()), Times.Once);
    }

    [TestMethod]
    public void Handle_DeletePlanCommand_CallsDeletePlanMethodInRepository()
    {
        // Arrange
        var deletePlanCommand = new DeletePlanCommand { PlanId = 0 };

        // Act
        _handler.Handle(deletePlanCommand);

        // Assert
        Mock.Get(_planRepository).Verify(x => x.DeletePlan(It.IsAny<int>()), Times.Once);
    }
}
