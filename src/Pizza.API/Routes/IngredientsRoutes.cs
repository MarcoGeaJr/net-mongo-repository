using Pizza.Domain.Ingredient;

namespace Pizza.API.Routes;

public static class IngredientsRoutes
{
	public static RouteGroupBuilder MapIngredients(this RouteGroupBuilder group)
	{
		group.MapGet("/", async (IIngredientRepository repository) =>
		{
			var ingredients = await repository.GetAll();

			if (!ingredients.Any()) return Results.NoContent();

			return Results.Ok(ingredients);
		}).Produces<IEnumerable<Ingredient>>();

		group.MapGet("/{id}", async (string id, IIngredientRepository repository) =>
		{
			var ingredient = await repository.GetById(id);

			if (ingredient == null) return Results.NotFound();

			return Results.Ok(ingredient);
		}).Produces<Ingredient>();

		group.MapPost("/", async (Ingredient ingredient, IIngredientRepository repository) =>
		{
			await repository.Add(ingredient);

			return Results.Created($"/ingredients/{ingredient.Id}", ingredient.Id);
		});

		group.MapPut("/{id}", async (string id, Ingredient ingredient, IIngredientRepository repository) =>
		{
			await repository.Update(ingredient);

			return Results.Ok();
		});

		group.MapDelete("/{id}", async (string id, IIngredientRepository repository) =>
		{
			var ingredient = await repository.GetById(id);

			if (ingredient == null) Results.NotFound();

			await repository.Delete(id);

			Results.Ok();
		});

		return group;
	}
}
