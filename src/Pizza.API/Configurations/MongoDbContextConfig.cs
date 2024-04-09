namespace Pizza.API.Configurations;

public class MongoDbContextConfig
{
	public string Database { get; set; }
	public int ConnectionPoolSize { get; set; }
}
