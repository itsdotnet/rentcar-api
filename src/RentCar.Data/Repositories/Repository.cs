using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RentCar.Domain.Commons;

namespace RentCar.Data.Repositories;

public class Repository<T> : IRepository<T> where T : Auditable
{
    private readonly DbSet<T> table;
    private readonly AppDbContext dbContext;

    public Repository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
        table = dbContext.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        await table.AddAsync(entity);

        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        EntityEntry<T> entry = this.dbContext.Update(entity);

        return entry.Entity;
    }

    public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
    {
        var entity = await this.SelectAsync(expression);

        if (entity is not null)
        {
            table.Remove(entity);
            return true;
        }

        return false;
    }

    public async Task<T> SelectAsync(Expression<Func<T, bool>> expression, string[] includes = null)
        => await this.SelectAll(expression, includes).FirstOrDefaultAsync(t => !t.IsDeleted);

    public IQueryable<T> SelectAll(Expression<Func<T, bool>> expression = null, string[] includes = null, bool isTracking = true)
    {
        var query = expression is null ? isTracking ? table : table.AsNoTracking()
            : isTracking ? table.Where(expression) : table.Where(expression).AsNoTracking();

        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        return query;
    }
    
    public async Task SaveAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}