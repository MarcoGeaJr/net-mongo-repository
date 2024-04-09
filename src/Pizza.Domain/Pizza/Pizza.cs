using Pizza.Domain.Shared;

namespace Pizza.Domain.Pizza;

public class Pizza : IEntity
{
	public string Id { get; set; }
	public string Name { get; set; }
	public decimal Price { get; set; }

	public List<PizzaIngredient> Ingredients { get; set; }
}
