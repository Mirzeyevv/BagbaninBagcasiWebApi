using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.DebtDTOs;

public class DebtGetDTO
{

    public Guid Id { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime DeletedAt { get; set; }
    public string? DeletedBy { get; set; }

    public Guid CustomerId { get; set; }
    public decimal Amount { get; set; }
    public DateTime DueDate { get; set; }
    public bool Status { get; set; }
    public Customer? Customer { get; set; }

}
