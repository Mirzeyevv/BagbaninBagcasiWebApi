using DAL.SqlServer.Context;
using DAL.SqlServer.Repositories.Abstractions;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SqlServer.Repositories.Implementations;
public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
{
    private readonly AppDbContext _context;

    public ReadRepository(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll(bool isTracking = true, params string[] includes)
    {
        var query = Table.AsQueryable();
        if (!isTracking)
        {
            query.AsNoTracking();
        }

        if (includes is not null && includes.Length > 0)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return query;
    }

    public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, bool isTracking = true, params string[] includes)
    {
        var query = Table.Where(expression).AsQueryable();
        if (!isTracking)
        {
            query.AsNoTracking();
        }

        if (includes is not null && includes.Length > 0)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return query;
    }

    public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, int page, int size, bool isTracking = true, params string[] includes)
    {
        var query = Table.Where(expression).Skip(page * size).Take(size);
        if (!isTracking)
        {
            query.AsNoTracking();
        }

        if (includes is not null && includes.Length > 0)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return query;
    }

    public async Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> expression, bool isTracking = true, params string[] includes)
    {
        var query = Table.AsQueryable();
        if (!isTracking)
        {
            query = query.AsNoTracking();
        }

        if (includes is not null && includes.Length > 0)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        T? entity = await query.FirstOrDefaultAsync(expression);
        return entity;
    }

    public async Task<T> GetByIdAsync(Guid id, params string[] includes)
    {
        var query = Table.AsQueryable();
        if (includes is not null && includes.Length > 0)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        T? entity = await query.FirstOrDefaultAsync(t => t.Id == id);
        return entity;
    }

    public async Task<int> GetDataCountAsync()
    {
        int count = await Table.CountAsync();
        return count;
    }


}
