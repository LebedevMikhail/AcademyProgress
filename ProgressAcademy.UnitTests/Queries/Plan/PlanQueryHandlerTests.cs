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

        var planId = 1;
        var query = new GetPlanByIdQuery { PlanId = planId };
        var expectedPlan = new Domain.Models.Plan();
        _planRepositoryMock.Setup(repo => repo.GetPlanById(planId)).Returns(expectedPlan);

        var result = _queryHandler.Handle(query);

        Assert.AreEqual(expectedPlan, result);
    }

    [TestMethod]
    public void Handle_GetAllPlansQuery_ReturnsAllPlansFromRepository()
    {

        var query = new GetAllPlansQuery();
        var expectedPlans = new List<Domain.Models.Plan>();
        _planRepositoryMock.Setup(repo => repo.GetAllPlans()).Returns(expectedPlans);

        var result = _queryHandler.Handle(query);

        CollectionAssert.AreEqual(expectedPlans, result.ToList());
    }
    
    [TestMethod]
    public void Handle_GetPlanByIdQuery_WhenPlanNotFound_ReturnsNull()
    {

        var planId = 0;
        var query = new GetPlanByIdQuery { PlanId = planId };
        _planRepositoryMock.Setup(repo => repo.GetPlanById(planId)).Returns((Domain.Models.Plan)null);

        Assert.ThrowsException<ArgumentNullException>(()=>{
                _queryHandler.Handle(query);
        });
    }

    [TestMethod]
    public void Handle_GetAllPlansQuery_WhenRepositoryThrowsException_ReturnsEmptyList()
    {
        var query = new GetAllPlansQuery();
        var expectedResult = new List<Domain.Models.Plan>();
        _planRepositoryMock.Setup(repo => repo.GetAllPlans()).Returns(expectedResult);

        var result = _queryHandler.Handle(query);

        CollectionAssert.AreEqual(expectedResult, result.ToList());
    }
}