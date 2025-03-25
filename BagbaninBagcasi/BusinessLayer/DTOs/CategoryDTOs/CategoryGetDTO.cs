using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.CategoryDTOs;

public class CategoryGetDTO
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; } = false;
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; } = string.Empty;
    public ICollection<Product> Products { get; set; } = new List<Product>();

}
