using MongoDB.Driver;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Infrastructure.Repositories;

/// <summary>
/// Repository for handling CRUD operations related to plans using MongoDB.
/// </summary>
public class PlanRepository : IPlanRepository
{
    private readonly IMongoCollection<Plan> _planCollection;

    /// <summary>
    /// Initializes a new instance of the <see cref="PlanRepository"/> class.
    /// </summary>
    /// <param name="database">MongoDB database instance.</param>
    public PlanRepository(IMongoDatabase database)
    {
        _planCollection = database.GetCollection<Plan>("plans");
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Plan>> GetAllPlansAsync(CancellationToken cancellationToken)
    {
        return await _planCollection.Find(_ => true).ToListAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Plan> GetPlanByIdAsync(int planId, CancellationToken cancellationToken)
    {
        return await _planCollection.Find(plan => plan.Id == planId).FirstOrDefaultAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task CreatePlanAsync(Plan plan, CancellationToken cancellationToken)
    {
        await _planCollection.InsertOneAsync(plan);
    }

    /// <inheritdoc/>
    public async Task UpdatePlanAsync(Plan plan, CancellationToken cancellationToken)
    {
        FilterDefinition<Plan> filter = Builders<Plan>.Filter.Eq("_id", plan.Id);
        UpdateDefinition<Plan> update = Builders<Plan>.Update
            .Set("Title", plan.Title);
        await _planCollection.UpdateOneAsync(filter, update, cancellationToken:cancellationToken);
    }

    /// <inheritdoc/>
    public async Task DeletePlanAsync(int planId, CancellationToken cancellationToken)
    {
        FilterDefinition<Plan> filter = Builders<Plan>.Filter.Eq("_id", planId);
       await _planCollection.DeleteOneAsync(filter, cancellationToken);
    }
}
