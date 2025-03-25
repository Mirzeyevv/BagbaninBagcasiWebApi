﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SqlServer.Repositories.Abstractions;

public interface ICustomerWriteRepository : IWriteRepository<Customer>
{
}
