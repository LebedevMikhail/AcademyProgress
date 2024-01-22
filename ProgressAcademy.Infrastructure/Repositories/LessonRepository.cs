using MongoDB.Driver;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Infrastructure.Repositories;

public class LessonRepository : ILessonRepository
{
    private readonly IMongoCollection<Lesson> _lessonCollection;

    public LessonRepository(IMongoDatabase database)
    {
        _lessonCollection = database.GetCollection<Lesson>("lessons");
    }

    public List<Lesson> GetAllLessons()
    {
        return _lessonCollection.Find(_ => true).ToList();
    }

    public Lesson GetLessonById(int lessonId)
    {
        return _lessonCollection.Find(lesson => lesson.Id == lessonId).FirstOrDefault();
    }

    public void CreateLesson(Lesson lesson)
    {
        _lessonCollection.InsertOne(lesson);
    }

    public void UpdateLesson(Lesson lesson)
    {
        FilterDefinition<Lesson> filter = Builders<Lesson>.Filter.Eq("_id", lesson.Id);
        UpdateDefinition<Lesson> update = Builders<Lesson>.Update
            .Set("Title", lesson.Title);
        _lessonCollection.UpdateOne(filter, update);
    }

    public void DeleteLesson(int lessonId)
    {
        FilterDefinition<Lesson> filter = Builders<Lesson>.Filter.Eq("_id", lessonId);
        _lessonCollection.DeleteOne(filter);
    }
}