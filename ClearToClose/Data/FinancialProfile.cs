using System.ComponentModel.DataAnnotations;

namespace ClearToClose.Data;

public class FinancialProfile
{
    public int Id { get; set; }

    public string UserId { get; set; } = string.Empty;

    [Range(0, 1_000_000)]
    public decimal MonthlyIncome { get; set; }

    [Range(0, 1)]
    public decimal GoalDti { get; set; } = 0.36m;
}
