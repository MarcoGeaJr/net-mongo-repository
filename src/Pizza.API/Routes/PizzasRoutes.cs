using Pizza.Domain.Pizza;

namespace Pizza.API.Routes;

public static class PizzasRoutes
{
	public static RouteGroupBuilder MapPizzas(this RouteGroupBuilder group)
	{
		group.MapGet("/", async (IPizzaRepository repository) =>
		{
			var pizzas = await repository.GetAll();

			if (!pizzas.Any()) return Results.NoContent();

			return Results.Ok(pizzas);
		}).Produces<IEnumerable<Domain.Pizza.Pizza>>();

		group.MapGet("/{id}", async (string id, IPizzaRepository repository) =>
		{
			var pizza = await repository.GetById(id);

			if (pizza == null) return Results.NotFound();

			return Results.Ok(pizza);
		}).Produces<Domain.Pizza.Pizza>();

		group.MapPost("/", async (Domain.Pizza.Pizza pizza, IPizzaRepository repository) =>
		{
			await repository.Add(pizza);

			return Results.Created($"/pizzas/{pizza.Id}", pizza.Id);
		});

		group.MapPut("/{id}", async (string id, Domain.Pizza.Pizza pizza, IPizzaRepository repository) =>
		{
			await repository.Update(pizza);

			return Results.Ok();
		});

		group.MapDelete("/{id}", async (string id, IPizzaRepository repository) =>
		{
			var pizza = await repository.GetById(id);

			if (pizza == null) Results.NotFound();

			await repository.Delete(id);

			Results.Ok();
		});

		return group;
	}
}
