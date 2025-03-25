using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Customer : AuditableEntity
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public decimal DebtAmount { get; set; }

    public ICollection<Sale> Sales { get; set; } = new List<Sale>();    
    public ICollection<Debt> Debts { get; set; } = new List<Debt>();

}
