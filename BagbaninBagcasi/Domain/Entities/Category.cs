using Domain.Entities.Common;

namespace Domain.Entities;

public class Category : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; } = string.Empty;

    public ICollection<Product> Products { get; set; } = new List<Product>();

}