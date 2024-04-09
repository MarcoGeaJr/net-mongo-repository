namespace Pizza.Domain.Shared;

public interface IRepository<T> where T : IEntity
{
	Task<IEnumerable<T>> GetAll();
	Task<T> GetById(string id);
	Task Add(T entity);
	Task Update(T entity);
	Task Delete(string id);
}
