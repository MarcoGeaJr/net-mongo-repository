using Pizza.Domain.Shared;

namespace Pizza.Domain.Ingredient;

public class Ingredient : IEntity
{
	public string Id { get; set; }
	public string Name { get; set; }
	public string UnitMeasurement { get; set; }
}
