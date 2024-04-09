using MongoDB.Driver;
using Pizza.Domain.Ingredient;
using Pizza.Infra.Mongo.Mappers;
using Pizza.Infra.Mongo.Repositories.Shared;

namespace Pizza.Infra.Mongo.Repositories;

public class IngredientRepository : Repository<Models.Ingredient>, IIngredientRepository
{
	public IngredientRepository(MongoDbContext database)
		: base(database.GetCollection<Models.Ingredient>(nameof(Models.Ingredient)))
	{
	}

	public async Task<IEnumerable<Domain.Ingredient.Ingredient>> GetAll()
	{
		var ingredients = await base.GetAll();

		if (ingredients?.Any() != true) return Enumerable.Empty<Domain.Ingredient.Ingredient>();

		return ingredients.Select(ingredient => ingredient.ToModel());
	}

	public async Task<Domain.Ingredient.Ingredient> GetById(string id)
	{
		var ingredient = await base.GetById(id);

		if (ingredient == null) return null;

		return ingredient.ToModel();
	}

	public async Task Add(Domain.Ingredient.Ingredient model)
	{
		var entity = model.ToEntity();

		await base.Add(entity);

		model.Id = entity.Id;
	}

	public async Task Update(Domain.Ingredient.Ingredient model)
	{
		await base.Update(model.ToEntity());
	}
}
