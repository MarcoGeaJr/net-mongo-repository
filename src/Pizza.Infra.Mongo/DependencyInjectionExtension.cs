using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Pizza.Domain.Ingredient;
using Pizza.Domain.Pizza;
using Pizza.Infra.Mongo.Repositories;

namespace Pizza.Infra.Mongo;

public static class DependencyInjectionExtension
{
	public static IServiceCollection AddMongoDbContext(
		this IServiceCollection services,
		string connectionString,
		string databaseName,
		int connectionPoolSize = 100)
	{
		var mongoClientSettings = MongoClientSettings.FromConnectionString(connectionString);
		mongoClientSettings.MaxConnectionPoolSize = connectionPoolSize;

		var mongoClient = new MongoClient(mongoClientSettings);
		var mongoDatabase = mongoClient.GetDatabase(databaseName);

		services.AddSingleton(new MongoDbContext(mongoDatabase));

		return services;
	}

	public static IServiceCollection AddRepositories(
		this IServiceCollection services)
	{
		services.AddScoped<IPizzaRepository, PizzaRepository>();
		services.AddScoped<IIngredientRepository, IngredientRepository>();

		return services;
	}
}
