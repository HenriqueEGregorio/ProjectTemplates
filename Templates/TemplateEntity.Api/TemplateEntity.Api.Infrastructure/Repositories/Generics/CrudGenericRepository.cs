using Microsoft.EntityFrameworkCore;
using TemplateEntity.Api.Domain.Filters;
using TemplateEntity.Api.Domain.Interfaces.Entities;
using TemplateEntity.Api.Domain.Interfaces.Repositories.Generics;
using TemplateEntity.Api.Domain.Pagination;
using TemplateEntity.Api.Infrastructure.Data;

namespace TemplateEntity.Api.Infrastructure.Repositories.Generics;

public class CrudGenericRepository<T> : ICrudGenericRepository<T> where T : class, IDefaultEntity
{
    private bool _disposed = false;
    private readonly Context _context;

    public CrudGenericRepository(Context context)
    {
        _context = context;
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        var query = _context.Set<T>().AsQueryable();

        var result = await query
            .AsTracking()
            .FirstOrDefaultAsync(x => EF.Property<Guid>(x, "Id") == id);

        return result;
    }

    public async Task<IEnumerable<T>> GetAsync()
    {
        var query = _context.Set<T>().AsQueryable();
        var orderedResult = query.OrderByDescending(x => EF.Property<int>(x, "Sequence"));

        var result = await orderedResult.ToListAsync();
        return result;
    }

    public async Task<IPagination<T>> GetPaginatedAsync(IDefaultFilter filter)
    {
        var query = _context.Set<T>().AsQueryable();
        int count = await query.CountAsync();
        var paginatedResult = query.OrderByDescending(x => EF.Property<int>(x, "Sequence"))
                                  .Skip((filter.PageIndex - 1) * filter.PageSize)
                                  .Take(filter.PageSize);

        var result = await paginatedResult.ToListAsync();
        return new Pagination<T>(result, count, pageIndex: filter.PageIndex, pageSize: filter.PageSize);
    }

    public async Task<T> AddAsync(T entity)
    {
        entity.CreationAt = DateTime.UtcNow;

        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task UpdateAsync(Guid id, T entity)
    {
        var existingEntity = await GetByIdAsync(id);

        if (existingEntity != null)
        {
            entity.Id = existingEntity.Id;
            entity.Sequence = existingEntity.Sequence;
            entity.UpdateAt = DateTime.UtcNow;
            entity.CreationAt = existingEntity.CreationAt;

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateRangeAsync(IEnumerable<T> entities)
    {
        _context.UpdateRange(entities);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Guid id)
    {
        var existingEntity = await GetByIdAsync(id);

        if (existingEntity != null)
        {
            _context.Remove(existingEntity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task RemoveRangeAsync(IEnumerable<T> entities)
    {
        _context.RemoveRange(entities);
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
                _context.Dispose();

            _disposed = true;
        }
    }
}
