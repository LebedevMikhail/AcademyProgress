using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ProgressAcademy.Domain.ReadModels;

namespace ProgressAcademy.Domain.Models;

public class Lesson {
    [BsonId]
    [BsonRepresentation(BsonType.Int32)]
    public int Id { get; set; }
    public string Title { get; set; }
    public string MeetingNotes {get;set;}
    public int LessonSocre {get;set;}
    public List<SimplifiedTheme> Themes {get;set;}
}
