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
        var createPlanCommand = new CreatePlanCommand { Plan = null };

        Assert.ThrowsException<ArgumentNullException>(() => _handler.Handle(createPlanCommand));
    }

    [TestMethod]
    public void Handle_UpdatePlanCommand_WithNullPlan_ThrowsArgumentNullException()
    {
        var updatePlanCommand = new UpdatePlanCommand { Plan = null };

        Assert.ThrowsException<ArgumentNullException>(() => _handler.Handle(updatePlanCommand));
    }

    [TestMethod]
    public void Handle_DeletePlanCommand_WithZeroPlanId_ThrowsArgumentNullException()
    {
        var deletePlanCommand = new DeletePlanCommand { PlanId = 0 };

        Assert.ThrowsException<ArgumentNullException>(() => _handler.Handle(deletePlanCommand));
    }
    
    [TestMethod]
    public void Handle_CreatePlanCommand_CallsCreatePlanMethodInRepository()
    {
        var createPlanCommand = new CreatePlanCommand { Plan = new Plan() };

        _handler.Handle(createPlanCommand);

        Mock.Get(_planRepository).Verify(x => x.CreatePlan(It.IsAny<Plan>()), Times.Once);
    }

    [TestMethod]
    public void Handle_UpdatePlanCommand_CallsUpdatePlanMethodInRepository()
    {
        var updatePlanCommand = new UpdatePlanCommand { Plan = new Plan() };

        _handler.Handle(updatePlanCommand);

        Mock.Get(_planRepository).Verify(x => x.UpdatePlan(It.IsAny<Plan>()), Times.Once);
    }

    [TestMethod]
    public void Handle_DeletePlanCommand_CallsDeletePlanMethodInRepository()
    {

        var deletePlanCommand = new DeletePlanCommand { PlanId = 0 };

        Assert.ThrowsException<ArgumentNullException>(()=>
            {
                _handler.Handle(deletePlanCommand);
            });
    }
}
