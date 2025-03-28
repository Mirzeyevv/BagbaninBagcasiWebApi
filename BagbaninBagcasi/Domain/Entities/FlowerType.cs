﻿using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class FlowerType : AuditableEntity
{
    public string Name { get; set; }
    public string Color { get; set; }
    public string Season { get; set; }
    public string GrowthType { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}

