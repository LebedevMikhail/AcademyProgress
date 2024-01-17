using MongoDB.Driver;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Infrastructure.Repositories;

public class PlanRepository : IPlanRepository
{
    private readonly IMongoCollection<Plan?> _planCollection;

    public PlanRepository(IMongoDatabase database)
    {
        _planCollection = database.GetCollection<Plan>("plans");
    }

    public List<Plan?> GetAllPlans()
    {
        return _planCollection.Find(_ => true).ToList();
    }

    public Plan GetPlanById(int planId)
    {
        return _planCollection.Find(plan => plan.Id == planId).FirstOrDefault();
    }

    public void CreatePlan(Plan? plan)
    {
        _planCollection.InsertOne(plan);
    }

    public void UpdatePlan(Plan plan)
    {
        FilterDefinition<Plan?> filter = Builders<Plan>.Filter.Eq("_id", plan.Id);
        UpdateDefinition<Plan?> update = Builders<Plan>.Update
            .Set("Title", plan.Title);
        _planCollection.UpdateOne(filter, update);
    }

    public void DeletePlan(int planId)
    {
        FilterDefinition<Plan?> filter = Builders<Plan>.Filter.Eq("_id", planId);
        _planCollection.DeleteOne(filter);
    }
}