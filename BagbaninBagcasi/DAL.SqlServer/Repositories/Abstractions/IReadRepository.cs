using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SqlServer.Repositories.Abstractions;
public interface IReadRepository<T> : IRepository<T> where T : BaseEntity, new()
{
    IQueryable<T> GetAll(bool isTracking = true, params string[] includes);
    IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, bool isTracking = true, params string[] includes);
    IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, int page, int size, bool isTracking = true, params string[] includes);
    Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> expression, bool isTracking = true, params string[] includes);
    Task<T> GetByIdAsync(Guid id, params string[] includes);
    Task<int> GetDataCountAsync();
}
