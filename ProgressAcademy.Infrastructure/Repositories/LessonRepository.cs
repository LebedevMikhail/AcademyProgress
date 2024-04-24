using MongoDB.Driver;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Infrastructure.Repositories;

/// <summary>
/// Repository for handling CRUD operations related to lessons using MongoDB.
/// </summary>
public class LessonRepository : ILessonRepository
{
    private readonly IMongoCollection<Lesson> _lessonCollection;

    /// <summary>
    /// Initializes a new instance of the <see cref="LessonRepository"/> class.
    /// </summary>
    /// <param name="database">MongoDB database instance.</param>
    public LessonRepository(IMongoDatabase database)
    {
        _lessonCollection = database.GetCollection<Lesson>("lessons");
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Lesson>> GetAllLessonsAsync(CancellationToken cancellationToken)
    {
        return await _lessonCollection.Find(_ => true).ToListAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Lesson> GetLessonByIdAsync(int lessonId, CancellationToken cancellationToken)
    {
        return await _lessonCollection.Find(lesson => lesson.Id == lessonId).FirstOrDefaultAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task CreateLessonAsync(Lesson lesson, CancellationToken cancellationToken)
    {
        var options = new InsertOneOptions
        {
            BypassDocumentValidation = true
        };
        await _lessonCollection.InsertOneAsync(lesson, options, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task UpdateLessonAsync(Lesson lesson, CancellationToken cancellationToken)
    {
        FilterDefinition<Lesson> filter = Builders<Lesson>.Filter.Eq("_id", lesson.Id);
        UpdateDefinition<Lesson> update = Builders<Lesson>.Update
            .Set("Title", lesson.Title);
        await _lessonCollection.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task DeleteLessonAsync(int lessonId, CancellationToken cancellationToken)
    {
        FilterDefinition<Lesson> filter = Builders<Lesson>.Filter.Eq("_id", lessonId);
        await _lessonCollection.DeleteOneAsync(filter, cancellationToken);
    }
}
