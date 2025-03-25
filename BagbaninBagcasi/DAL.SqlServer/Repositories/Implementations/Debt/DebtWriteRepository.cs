using DAL.SqlServer.Context;
using DAL.SqlServer.Repositories.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SqlServer.Repositories.Implementations;

public class DebtWriteRepository : WriteRepository<Debt>, IDebtWriteRepository
{
    public DebtWriteRepository(AppDbContext context) : base(context)
    {
    }
}
