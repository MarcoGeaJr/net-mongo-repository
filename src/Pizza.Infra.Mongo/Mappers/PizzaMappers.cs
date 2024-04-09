namespace Pizza.Infra.Mongo.Mappers;

internal static class PizzaMapper
{
	public static Models.Pizza ToEntity(this Domain.Pizza.Pizza pizza)
		=> new()
		{
			Id = pizza.Id,
			Name = pizza.Name,
			Price = pizza.Price,
			Ingredients = pizza.Ingredients.ConvertAll(ingredient => ingredient.ToEntity())
		};

	public static Models.PizzaIngredient ToEntity(this Domain.Pizza.PizzaIngredient ingredient)
		=> new()
		{
			Name = ingredient.Name,
			Amount = ingredient.Amount,
			UnitMeasurement = ingredient.UnitMeasurement,
		};

	public static Domain.Pizza.Pizza ToModel(this Models.Pizza pizza)
		=> new()
		{
			Id = pizza.Id,
			Name = pizza.Name,
			Price = pizza.Price,
			Ingredients = pizza.Ingredients.Select(ingredient => ingredient.ToModel()).ToList(),
		};

	public static Domain.Pizza.PizzaIngredient ToModel(this Models.PizzaIngredient ingredient)
		=> new()
		{
			Name = ingredient.Name,
			Amount = ingredient.Amount,
			UnitMeasurement = ingredient.UnitMeasurement,
		};
}
