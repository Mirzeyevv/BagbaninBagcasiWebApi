using Domain.Entities.Common;
using Domain.Enums;
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
    public List<Season> Seasons { get; set; } = new List<Season>();
    public List<GrowthType> GrowthTypes { get; set; } = new List<GrowthType>();
    public ICollection<Product> Products { get; set; } = new List<Product>();

}

