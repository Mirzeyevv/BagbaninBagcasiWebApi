using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace DAL.SqlServer.Repositories.Abstractions;

public interface ICategoryWriteRepository : IWriteRepository<Category>
{
}
