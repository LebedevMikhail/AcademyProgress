using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProgressAcademy.Application.Queries;
using ProgressAcademy.Application.Queries.Plan;
using ProgressAcademy.Domain.Repositories;
using ProgressAcademy.Handlers.Queries;

namespace ProgressAcademy.UnitTests.Queries.Plan;

[TestClass]
public class PlanQueryHandlerTests
{
    private  Mock<IPlanRepository>? _planRepositoryMock;
    private PlanQueryHandler? _queryHandler;

    [TestInitialize]
    public void TestInitialize()
    {
        _planRepositoryMock = new Mock<IPlanRepository>();
        _queryHandler = new PlanQueryHandler(_planRepositoryMock.Object);
    }

    [TestMethod]
    public async Task Handle_GetPlanByIdQuery_ReturnsPlanFromRepository()
    {
        var planId = 1;
        var query = new GetPlanByIdQuery { PlanId = planId };
        var expectedPlan = new Domain.Models.Plan();
        var cancellationTokenSource = new CancellationTokenSource();
        _planRepositoryMock.Setup(repo => repo.GetPlanByIdAsync(planId, cancellationTokenSource.Token)).ReturnsAsync(expectedPlan);

        var result = await _queryHandler.Handle(query, cancellationTokenSource.Token);

        Assert.AreEqual(expectedPlan, result);
    }

    [TestMethod]
    public async Task Handle_GetAllPlansQuery_ReturnsAllPlansFromRepository()
    {
        var query = new GetAllPlansQuery();
        var expectedPlans = new List<Domain.Models.Plan>();
        var cancellationTokenSource = new CancellationTokenSource();
        _planRepositoryMock.Setup(repo => repo.GetAllPlansAsync(cancellationTokenSource.Token)).ReturnsAsync(expectedPlans);

        var result = await _queryHandler.Handle(query, cancellationTokenSource.Token);

        CollectionAssert.AreEqual(expectedPlans, result.ToList());
    }
    
    [TestMethod]
    public async Task Handle_GetPlanByIdQuery_WhenPlanNotFound_ReturnsNull()
    {

        var planId = 0;
        var query = new GetPlanByIdQuery { PlanId = planId };
        var cancellationTokenSource = new CancellationTokenSource();
        _planRepositoryMock.Setup(repo => repo.GetPlanByIdAsync(planId, cancellationTokenSource.Token)).ReturnsAsync((Domain.Models.Plan)null);

        await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await _queryHandler.Handle(query, cancellationTokenSource.Token));
    }

    [TestMethod]
    public async Task Handle_GetAllPlansQuery_WhenRepositoryThrowsException_ReturnsEmptyList()
    {
        var query = new GetAllPlansQuery();
        var expectedResult = new List<Domain.Models.Plan>();
        var cancellationTokenSource = new CancellationTokenSource();
        _planRepositoryMock.Setup(repo => repo.GetAllPlansAsync(cancellationTokenSource.Token)).ReturnsAsync(expectedResult);

        var result = await _queryHandler.Handle(query, cancellationTokenSource.Token);

        CollectionAssert.AreEqual(expectedResult, result.ToList());
    }
}