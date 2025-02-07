﻿using MongoDB.Driver;

namespace Pizza.Infra.Mongo;

public class MongoDbContext
{
	private readonly IMongoDatabase _database;

	public MongoDbContext(
		IMongoDatabase database)
	{
		_database = database;
	}

	public IMongoCollection<T> GetCollection<T>(string name)
	{
		return _database.GetCollection<T>(name);
	}
}
