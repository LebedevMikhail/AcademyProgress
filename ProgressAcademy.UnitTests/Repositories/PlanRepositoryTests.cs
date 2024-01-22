using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MongoDB.Driver;
using ProgressAcademy.Infrastructure.Repositories;
using ProgressAcademy.Domain.Repositories;
using ProgressAcademy.Domain.Models;

namespace ProgressAcademy.UnitTests.Repositories;

[TestClass]
public class PlanRepositoryTests
{
    private Mock<IMongoDatabase> _mongoDatabaseMock;
    private Mock<IMongoCollection<Plan>> _planCollectionMock;
    private IPlanRepository _planRepository;

    [TestInitialize]
    public void TestInitialize()
    {
        _mongoDatabaseMock = new Mock<IMongoDatabase>();
        _planCollectionMock = new Mock<IMongoCollection<Plan>>();
        _mongoDatabaseMock.Setup(db => db.GetCollection<Plan>("plans", null)).Returns(_planCollectionMock.Object);
        _planRepository = new PlanRepository(_mongoDatabaseMock.Object);
    }

    [TestMethod]
    public void GetAllPlans_ReturnsListOfPlans()
    {
        // Arrange
        var plans = new List<Plan> ();
        _planCollectionMock.Setup(collection => collection.Find(It.IsAny<FilterDefinition<Plan>>(), It.IsAny<FindOptions<Plan, Plan>>()))
            .Returns(new Mock<IAsyncCursor<Plan>>().Object);
        _planCollectionMock.Setup(cursor => cursor.ToList()).Returns(plans);

        // Act
        var result = _planRepository.GetAllPlans();

        // Assert
        CollectionAssert.AreEqual(plans, result);
    }

    [TestMethod]
    public void GetPlanById_WithExistingPlanId_ReturnsPlan()
    {
        // Arrange
        var planId = 1;
        var plan = new Plan { Id = planId };
        _planCollectionMock.Setup(collection => collection.Find(It.IsAny<FilterDefinition<Plan>>(), It.IsAny<FindOptions<Plan, Plan>>()))
            .Returns(new Mock<IAsyncCursor<Plan>>().Object);
        _planCollectionMock.Setup(cursor => cursor.FirstOrDefault()).Returns(plan);

        // Act
        var result = _planRepository.GetPlanById(planId);

        // Assert
        Assert.AreEqual(plan, result);
    }

    [TestMethod]
    public void GetPlanById_WithNonExistingPlanId_ReturnsNull()
    {
        // Arrange
        var planId = 1;
        _planCollectionMock.Setup(collection => collection.Find(It.IsAny<FilterDefinition<Plan>>(), It.IsAny<FindOptions<Plan, Plan>>()))
            .Returns(new Mock<IAsyncCursor<Plan>>().Object);
        _planCollectionMock.Setup(cursor => cursor.FirstOrDefault()).Returns((Plan)null);

        // Act
        var result = _planRepository.GetPlanById(planId);

        // Assert
        Assert.IsNull(result);
    }

    [TestMethod]
    public void CreatePlan_InsertsPlanIntoCollection()
    {
        // Arrange
        var plan = new Plan();

        // Act
        _planRepository.CreatePlan(plan);

        // Assert
        _planCollectionMock.Verify(collection => collection.InsertOne(plan), Times.Once);
    }

    [TestMethod]
    public void UpdatePlan_UpdatesPlanInCollection()
    {
        // Arrange
        var plan = new Plan { Id = 1, Title = "Old Title" };
        var updatedPlan = new Plan { Id = 1, Title = "New Title" };
        var filter = Builders<Plan>.Filter.Eq("_id", plan.Id);
        var updateDefinition = Builders<Plan>.Update.Set("Title", updatedPlan.Title);

        _planCollectionMock.Setup(collection => collection.UpdateOne(filter, updateDefinition));

        // Act
        _planRepository.UpdatePlan(updatedPlan);

        // Assert
        _planCollectionMock.Verify(collection => collection.UpdateOne(filter, updateDefinition), Times.Once);
    }

    [TestMethod]
    public void DeletePlan_RemovesPlanFromCollection()
    {
        // Arrange
        var planId = 1;
        var filter = Builders<Plan>.Filter.Eq("_id", planId);

        _planCollectionMock.Setup(collection => collection.DeleteOne(filter));

        // Act
        _planRepository.DeletePlan(planId);

        // Assert
        _planCollectionMock.Verify(collection => collection.DeleteOne(filter), Times.Once);
    }
}