﻿using Domain.Entities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Product : AuditableEntity
{

    public string Name { get; set; }
    public Guid? FlowerTypeId { get; set; }
    public Guid CategoryId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal Discount { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public FlowerType? FlowerType { get; set; }
    public Category? Category { get; set; }


}

