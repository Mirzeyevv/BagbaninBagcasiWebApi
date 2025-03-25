using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.FlowerTypeDTOs;

public class FlowerTypePostDTO
{
    public string Name { get; set; }
    public string Color { get; set; }
    public string Season { get; set; }
    public string GrowthType { get; set; }


}
