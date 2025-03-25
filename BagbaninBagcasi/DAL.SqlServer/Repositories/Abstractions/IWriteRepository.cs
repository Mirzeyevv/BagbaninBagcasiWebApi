﻿using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SqlServer.Repositories.Abstractions;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity, new()
{
    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task SaveAsync();

}