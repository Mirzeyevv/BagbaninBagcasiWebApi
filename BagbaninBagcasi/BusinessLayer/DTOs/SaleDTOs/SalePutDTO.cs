using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.SaleDTOs;

public class SalePutDTO
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public Guid? CustomerId { get; set; }
    public PaymentType PaymentType { get; set; }
}
