using System.Linq.Expressions;
using GameLibrary.Domain;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.Persistence;

public class DomainRepository<T>(GameLibraryDbContext dbContext) : IRepository<T> where T : DomainEntity
{
    public async Task<T?> GetByIdAsync(Guid id) => await dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);

    public async Task<IEnumerable<T>?> GetAllAsync() => await dbContext.Set<T>().ToListAsync();

    public async Task<IEnumerable<T>?> FindAsync(Expression<Func<T, bool>> predicate) => await dbContext.Set<T>().Where(predicate).ToListAsync();

    public async Task<T?> CreateAsync(T entity)
    {
        try
        {
            dbContext.Set<T>().Add(entity);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            return null;
        }

        return entity;
    }
    
    public async Task DeleteByIdAsync(Guid id)
    {
        var entity = await dbContext.Set<T>().FindAsync(id);
        
        if (entity is null)
        {
            return;
        }
        
        dbContext.Set<T>().Remove(entity);
        await dbContext.SaveChangesAsync();
    }
}