﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SqlServer.Repositories.Abstractions;

public interface IExpenseReadRepository : IReadRepository<Expense>
{
}
