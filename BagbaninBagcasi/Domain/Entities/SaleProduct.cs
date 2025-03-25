using Domain.Entities.Common;

namespace Domain.Entities;

public class SaleProduct : BaseEntity
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public Guid SaleId { get; set; }

    public Product? Product { get; set; }

    public Sale? Sale { get; set; }

}