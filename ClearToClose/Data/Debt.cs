using System.ComponentModel.DataAnnotations;

namespace ClearToClose.Data;

public class Debt
{
    public int Id { get; set; }

    public string UserId { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Range(0, 1_000_000)]
    public decimal MonthlyPayment { get; set; }
}
