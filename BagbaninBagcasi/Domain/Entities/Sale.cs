using Domain.Entities.Common;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Sale : AuditableEntity
{
    public string UserId { get; set; }
    public Guid? CustomerId { get; set; }
    public PaymentType PaymentType { get; set; }
    public IdentityUser? User { get; set; }
    public Customer? Customer { get; set; }

    public ICollection<SaleProduct> SaleProducts { get; set; } = new List<SaleProduct>();
}

