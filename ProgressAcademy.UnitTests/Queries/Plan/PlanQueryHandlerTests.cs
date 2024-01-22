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
    private Mock<IPlanRepository> _planRepositoryMock;
    private PlanQueryHandler _queryHandler;

    [TestInitialize]
    public void TestInitialize()
    {
        _planRepositoryMock = new Mock<IPlanRepository>();
        _queryHandler = new PlanQueryHandler(_planRepositoryMock.Object);
    }

    [TestMethod]
    public void Handle_GetPlanByIdQuery_ReturnsPlanFromRepository()
    {
        // Arrange
        var planId = 0;
        var query = new GetPlanByIdQuery { PlanId = planId };
        var expectedPlan = new Domain.Models.Plan();
        _planRepositoryMock.Setup(repo => repo.GetPlanById(planId)).Returns(expectedPlan);

        // Act
        var result = _queryHandler.Handle(query);

        // Assert
        Assert.AreEqual(expectedPlan, result);
    }

    [TestMethod]
    public void Handle_GetAllPlansQuery_ReturnsAllPlansFromRepository()
    {
        // Arrange
        var query = new GetAllPlansQuery();
        var expectedPlans = new List<Domain.Models.Plan>();
        _planRepositoryMock.Setup(repo => repo.GetAllPlans()).Returns(expectedPlans);

        // Act
        var result = _queryHandler.Handle(query);

        // Assert
        CollectionAssert.AreEqual(expectedPlans, result.ToList());
    }
    
    [TestMethod]
    public void Handle_GetPlanByIdQuery_WhenPlanNotFound_ReturnsNull()
    {
        // Arrange
        var planId = 0;
        var query = new GetPlanByIdQuery { PlanId = planId };
        _planRepositoryMock.Setup(repo => repo.GetPlanById(planId)).Returns((Domain.Models.Plan)null);

        // Act
        var result = _queryHandler.Handle(query);

        // Assert
        Assert.IsNull(result);
    }

    [TestMethod]
    public void Handle_GetAllPlansQuery_WhenRepositoryThrowsException_ReturnsEmptyList()
    {
        // Arrange
        var query = new GetAllPlansQuery();
        _planRepositoryMock.Setup(repo => repo.GetAllPlans()).Throws(new Exception("Simulated exception"));

        // Act
        var result = _queryHandler.Handle(query);

        // Assert
        CollectionAssert.AreEqual(new List<Domain.Models.Plan>(), result.ToList());
    }
}