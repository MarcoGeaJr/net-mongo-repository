using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Pizza.Domain.Shared;

namespace Pizza.Infra.Mongo.Models;

public class Pizza : IEntity
{
	[BsonId]
	[BsonRepresentation(BsonType.ObjectId)]
	public string? Id { get; set; }

	public required string Name { get; set; }
	public decimal Price { get; set; }

	public required ICollection<PizzaIngredient> Ingredients { get; set; }
}
