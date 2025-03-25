using Domain.Entities.Common;

namespace Domain.Entities;

public class ExpenseType : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; } = string.Empty;

    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();

}