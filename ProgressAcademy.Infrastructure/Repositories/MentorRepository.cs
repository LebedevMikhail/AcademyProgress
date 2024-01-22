using MongoDB.Driver;
using ProgressAcademy.Domain.Models;
using ProgressAcademy.Domain.Repositories;

namespace ProgressAcademy.Infrastructure.Repositories;

public class MentorRepository : IMentorRepository
{
    private readonly IMongoCollection<Mentor> _mentorCollection;

    public MentorRepository(IMongoDatabase database)
    {
        _mentorCollection = database.GetCollection<Mentor>("mentors");
    }

    public List<Mentor> GetAllMentors()
    {
        return _mentorCollection.Find(_ => true).ToList();
    }

    public Mentor GetMentorById(int mentorId)
    {
        return _mentorCollection.Find(mentor => mentor.Id == mentorId).FirstOrDefault();
    }

    public void CreateMentor(Mentor mentor)
    {
        _mentorCollection.InsertOne(mentor);
    }

    public void UpdateMentor(Mentor mentor)
    {
        FilterDefinition<Mentor> filter = Builders<Mentor>.Filter.Eq("_id", mentor.Id);
        UpdateDefinition<Mentor> update = Builders<Mentor>.Update
            .Set("Title", mentor.FullName);
        _mentorCollection.UpdateOne(filter, update);
    }

    public void DeleteMentor(int mentorId)
    {
        FilterDefinition<Mentor> filter = Builders<Mentor>.Filter.Eq("_id", mentorId);
        _mentorCollection.DeleteOne(filter);
    }
}