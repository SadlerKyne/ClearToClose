using System.ComponentModel.DataAnnotations;

namespace ClearToClose.Data;

public class Purchase
{
    public int Id { get; set; }

    public string UserId { get; set; } = string.Empty;

    [Required, StringLength(150)]
    public string Description { get; set; } = string.Empty;

    [Range(0, 1_000_000)]
    public decimal Amount { get; set; }

    [Required, StringLength(50)]
    public string Category { get; set; } = string.Empty;

    public DateOnly Date { get; set; }
}
