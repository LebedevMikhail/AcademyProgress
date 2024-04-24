using MongoDB.Driver;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Infrastructure.Repositories;

/// <summary>
/// Repository for handling CRUD operations related to mentors using MongoDB.
/// </summary>
public class MentorRepository : IMentorRepository
{
    private readonly IMongoCollection<Mentor> _mentorCollection;

    /// <summary>
    /// Initializes a new instance of the <see cref="MentorRepository"/> class.
    /// </summary>
    /// <param name="database">MongoDB database instance.</param>
    public MentorRepository(IMongoDatabase database)
    {
        _mentorCollection = database.GetCollection<Mentor>("mentors");
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Mentor>> GetAllMentorsAsync(CancellationToken cancellationToken)
    {
        return await _mentorCollection.Find(_ => true).ToListAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Mentor> GetMentorByIdAsync(int mentorId, CancellationToken cancellationToken)
    {
        return await _mentorCollection.Find(mentor => mentor.Id == mentorId).FirstOrDefaultAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task CreateMentorAsync(Mentor mentor, CancellationToken cancellationToken)
    {
        await _mentorCollection.InsertOneAsync(mentor, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task UpdateMentorAsync(Mentor mentor, CancellationToken cancellationToken)
    {
        FilterDefinition<Mentor> filter = Builders<Mentor>.Filter.Eq("_id", mentor.Id);
        UpdateDefinition<Mentor> update = Builders<Mentor>.Update
            .Set("Title", mentor.FullName);
        await _mentorCollection.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task DeleteMentorAsync(int mentorId, CancellationToken cancellationToken)
    {
        FilterDefinition<Mentor> filter = Builders<Mentor>.Filter.Eq("_id", mentorId);
        await _mentorCollection.DeleteOneAsync(filter, cancellationToken);
    }
}
