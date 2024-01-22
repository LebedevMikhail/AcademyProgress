using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ProgressAcademy.Domain.ReadModels.Lessons;

namespace ProgressAcademy.Domain.Models;

public class Mentor
{
    [BsonId]
    [BsonRepresentation(BsonType.Int32)]
    public int Id { get; set; }
    public string FullName { get; set; }
    public List<SimplifiedMentee> Mentees {get;set;}
}