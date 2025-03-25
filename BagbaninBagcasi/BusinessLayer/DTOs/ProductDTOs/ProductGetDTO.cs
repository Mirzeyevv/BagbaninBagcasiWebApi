using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.ProductDTOs;

public class ProductGetDTO
{

    public Guid Id { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime DeletedAt { get; set; }
    public string? DeletedBy { get; set; }

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
