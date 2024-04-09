using Pizza.API.Configurations;
using Pizza.Infra.Mongo;

namespace Pizza.API.Extensions;

public static class ConfigureContextsExtensions
{
	public static IServiceCollection ConfigureContexts(
		this IServiceCollection services,
		IConfiguration configuration)
	{
		services.AddMongoContext(configuration);

		// Add Sql context
		// Add Redis context
		// ...

		return services;
	}

	private static IServiceCollection AddMongoContext(
		this IServiceCollection services,
		IConfiguration configuration)
	{
		var connString = configuration.GetConnectionString("MongoDb");
		MongoDbContextConfig mongoConfig = configuration.GetSection(nameof(MongoDbContextConfig)).Get<MongoDbContextConfig>();

		return services.AddMongoDbContext(
			connectionString: connString,
			databaseName: mongoConfig.Database,
			connectionPoolSize: mongoConfig.ConnectionPoolSize);
	}
}
