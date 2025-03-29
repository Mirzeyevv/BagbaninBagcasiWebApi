using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Debt : AuditableEntity
{
    public Guid CustomerId { get; set; }
    public decimal Amount { get; set; }
    public decimal PaidAmount { get; set; }
    public DateTime DueDate { get; set; }
    public bool Status { get; set; }
    public Customer? Customer { get; set; }
}
