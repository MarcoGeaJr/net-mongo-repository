using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Pizza.Domain.Shared;

namespace Pizza.Infra.Mongo.Models;

public class Ingredient : IEntity
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string? Id { get; set; }

	public required string Name { get; set; }
	public required string UnitMeasurement { get; set; }
}
