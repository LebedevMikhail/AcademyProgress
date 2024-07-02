using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using ProgressAcademy.Domain.Models;

public class MultipleChoiceQuestionSerializer : SerializerBase<MultipleChoiceQuestion>
{
    /// <summary>
    /// Deserializes a BSON document into a MultipleChoiceQuestion object.
    /// </summary>
    /// <param name="context">The context for BSON deserialization.</param>
    /// <param name="args">The arguments for BSON deserialization.</param>
    /// <returns>A MultipleChoiceQuestion object corresponding to the BSON data.</returns>
    public override MultipleChoiceQuestion Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var document = BsonSerializer.Deserialize<BsonDocument>(context.Reader);
        return new MultipleChoiceQuestion
        {
            Id = document["_id"].AsInt32,
            Question = document["question"].AsString,
            Options = document["options"].AsBsonArray.Select(p => p.AsString).ToList(),
            Answers = document["answers"].AsBsonArray.Select(p => p.AsString).ToList()
        };
    }
    /// <summary>
    /// Serializes a MultipleChoiceQuestion object into a BSON document.
    /// </summary>
    /// <param name="context">The context for BSON serialization.</param>
    /// <param name="args">The arguments for BSON serialization.</param>
    /// <returns>A BSON data corresponding to the MultipleChoiceQuestion object.</returns>
  
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, MultipleChoiceQuestion value)
    {
        var document = new BsonDocument
        {
            { "_id", value.Id },
            { "question", value.Question },
            { "options", new BsonArray(value.Options) },
            { "answers", new BsonArray(value.Answers) }
        };
        BsonSerializer.Serialize(context.Writer, document);
    }
}
