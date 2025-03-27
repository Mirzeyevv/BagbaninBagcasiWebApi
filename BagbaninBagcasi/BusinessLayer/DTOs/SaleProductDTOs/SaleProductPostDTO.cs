﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.SaleProductDTOs;

public class SaleProductPostDTO
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public Guid SaleId { get; set; }

}
