using eCommerceApp.Application.Exceptions;
using eCommerceApp.Domain.Interfaces;
using eCommerceApp.Infrastructure.Data;
using eCommerceApp.Application.Exceptions;

namespace eCommerceApp.Infrastructure.Repositories;

public class GenericRepository<TEntity>(AppDbContext context) : IGeneric<TEntity> where TEntity : class
{
    
    public async Task<int> AddAsync(TEntity entity)
    {
        context.Set<TEntity>().Add(entity);
        return await context.SaveChangesAsync();
    }

    public Task<TEntity> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAsync(Guid id)
    {
        var entity = await context.Set<TEntity>().FindAsync(id);
        if (entity == null)
            throw new ItemNotFoundException($"Item with id {id} is not found");
        await context.SaveChangesAsync();
        
        context.Set<TEntity>().Add(entity);
        return await context.SaveChangesAsync();
    }

    public Task<IEnumerable<TEntity>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}

