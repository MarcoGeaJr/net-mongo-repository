using MongoDB.Driver;
using Pizza.Domain.Pizza;
using Pizza.Infra.Mongo.Mappers;
using Pizza.Infra.Mongo.Repositories.Shared;

namespace Pizza.Infra.Mongo.Repositories;

public class PizzaRepository : Repository<Models.Pizza>, IPizzaRepository
{
	public PizzaRepository(MongoDbContext database)
		: base(database.GetCollection<Models.Pizza>(nameof(Models.Pizza)))
	{
	}

	public async Task<IEnumerable<Domain.Pizza.Pizza>> GetAll()
	{
		var pizzas = await base.GetAll();

		if (pizzas?.Any() != true) return Enumerable.Empty<Domain.Pizza.Pizza>();

		return pizzas.Select(pizza => pizza.ToModel());
	}

	public async Task<Domain.Pizza.Pizza> GetById(string id)
	{
		var pizza = await base.GetById(id);

		if (pizza == null) return null;

		return pizza.ToModel();
	}

	public async Task Add(Domain.Pizza.Pizza model)
	{
		var entity = model.ToEntity();

		await base.Add(entity);

		model.Id = entity.Id;
	}

	public async Task Update(Domain.Pizza.Pizza model)
	{
		await base.Update(model.ToEntity());
	}
}
