using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ProgressAcademy.Domain.ReadModels.Lessons;

namespace ProgressAcademy.Domain.Models;

public class Plan
{
    [BsonId]
    [BsonRepresentation(BsonType.Int32)]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Grade { get; set; }
    public string Description { get; set; }
    public string Task { get; set; }
    public int CurrentProgress { get; set; }
    public List<SimplifiedLesson> Lessons { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Goal { get; set; }
}