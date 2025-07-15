using System.Linq.Expressions;
using GameLibrary.Domain;

namespace GameLibrary.Persistence;

public interface IRepository<T> where T : IDomainEntity
{
    Task<T?> GetByIdAsync(Guid id);
    
    Task<IEnumerable<T>?> GetAllAsync();
    
    Task<IEnumerable<T>?> FindAsync(Expression<Func<T, bool>> predicate);
    
    Task<T?> CreateAsync(T entity);
    
    Task DeleteAsync(T entity);
}