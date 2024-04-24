using MongoDB.Driver;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Infrastructure.Repositories;

/// <summary>
/// Repository for handling CRUD operations related to mentees using MongoDB.
/// </summary>
public class MenteeRepository : IMenteeRepository
{
    private readonly IMongoCollection<Mentee> _menteeCollection;

    /// <summary>
    /// Initializes a new instance of the <see cref="MenteeRepository"/> class.
    /// </summary>
    /// <param name="database">MongoDB database instance.</param>
    public MenteeRepository(IMongoDatabase database)
    {
        _menteeCollection = database.GetCollection<Mentee>("mentees");
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Mentee>> GetAllMenteesAsync(CancellationToken cancellationToken)
    {
        return await _menteeCollection.Find(_ => true).ToListAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Mentee> GetMenteeByIdAsync(int menteeId, CancellationToken cancellationToken)
    {
        return await _menteeCollection.Find(mentee => mentee.Id == menteeId).FirstOrDefaultAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task CreateMenteeAsync(Mentee mentee, CancellationToken cancellationToken)
    {
        await _menteeCollection.InsertOneAsync(mentee);
    }

    /// <inheritdoc/>
    public async Task UpdateMenteeAsync(Mentee mentee, CancellationToken cancellationToken)
    {
        FilterDefinition<Mentee> filter = Builders<Mentee>.Filter.Eq("_id", mentee.Id);
        UpdateDefinition<Mentee> update = Builders<Mentee>.Update
            .Set("FullName", mentee.FullName);
        await _menteeCollection.UpdateOneAsync(filter, update);
    }

    /// <inheritdoc/>
    public async Task DeleteMenteeAsync(int menteeId, CancellationToken cancellationToken)
    {
        FilterDefinition<Mentee> filter = Builders<Mentee>.Filter.Eq("_id", menteeId);
       await  _menteeCollection.DeleteOneAsync(filter, cancellationToken);
    }
}
