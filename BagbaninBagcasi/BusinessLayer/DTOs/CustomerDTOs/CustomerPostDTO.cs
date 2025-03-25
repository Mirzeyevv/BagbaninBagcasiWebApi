using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.CustomerDTOs;

public class CustomerPostDTO
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public decimal DebtAmount { get; set; }

}
