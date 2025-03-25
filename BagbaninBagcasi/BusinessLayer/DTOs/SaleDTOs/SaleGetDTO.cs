using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.SaleDTOs;

public class SaleGetDTO
{

    public Guid Id { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime DeletedAt { get; set; }
    public string? DeletedBy { get; set; }

    public string UserId { get; set; }
    public Guid? CustomerId { get; set; }
    public PaymentType PaymentType { get; set; }
    public IdentityUser? User { get; set; }
    public Customer? Customer { get; set; }

    public ICollection<SaleProduct> SaleProducts { get; set; } = new List<SaleProduct>();

}
