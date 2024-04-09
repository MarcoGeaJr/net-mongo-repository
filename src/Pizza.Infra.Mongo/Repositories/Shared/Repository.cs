using MongoDB.Driver;
using Pizza.Domain.Shared;

namespace Pizza.Infra.Mongo.Repositories.Shared;

public class Repository<T> : IRepository<T> where T : IEntity
{
	private readonly IMongoCollection<T> _collection;

	public Repository(IMongoCollection<T> collection)
	{
		_collection = collection;
	}

	public async Task<IEnumerable<T>> GetAll()
	{
		return await _collection.Find(_ => true).ToListAsync();
	}

	public async Task<T> GetById(string id)
	{
		var filter = Builders<T>.Filter.Eq(x => x.Id, id);
		return await _collection.Find(filter).FirstOrDefaultAsync();
	}

	public async Task Add(T entity)
	{
		await _collection.InsertOneAsync(entity);
	}

	public async Task Update(T entity)
	{
		await _collection.ReplaceOneAsync(
			Builders<T>.Filter.Eq(x => x.Id, entity.Id),
			entity);
	}

	public async Task Delete(string id)
	{
		var filter = Builders<T>.Filter.Eq(x => x.Id, id);
		await _collection.DeleteOneAsync(filter);
	}
}
