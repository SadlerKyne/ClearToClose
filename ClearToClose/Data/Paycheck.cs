using System.ComponentModel.DataAnnotations;

namespace ClearToClose.Data;

public class Paycheck
{
    public int Id { get; set; }

    public string UserId { get; set; } = string.Empty;

    [Range(0, 1_000_000)]
    public decimal Amount { get; set; }

    public DateOnly DateReceived { get; set; }
}
