using Pizza.API.Routes;

namespace Pizza.API.Extensions;

public static class RoutesExtensions
{
	public static void MapRoutes(this WebApplication app)
	{
		app.MapGroup("/ingredients")
			.MapIngredients();

		app.MapGroup("/pizzas")
			.MapPizzas();
	}
}
