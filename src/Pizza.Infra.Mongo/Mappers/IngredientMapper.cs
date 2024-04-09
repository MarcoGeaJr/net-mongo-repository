namespace Pizza.Infra.Mongo.Mappers;

internal static class IngredientMapper
{
	public static Models.Ingredient ToEntity(this Domain.Ingredient.Ingredient ingredient)
		=> new()
		{
			Id = ingredient.Id,
			Name = ingredient.Name,
			UnitMeasurement = ingredient.UnitMeasurement
		};

	public static Domain.Ingredient.Ingredient ToModel(this Models.Ingredient ingredient)
		=> new()
		{
			Id = ingredient.Id,
			Name = ingredient.Name,
			UnitMeasurement = ingredient.UnitMeasurement
		};
}
