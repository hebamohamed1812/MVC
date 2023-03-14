using lab2.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace lab2.Models.View;
public record AddTicket
{
    // [DataType(DataType.Text)]
    public string Description { get; init; } = string.Empty;

    [Display(Name = "Is Closed")]
    public bool IsClosed { get; init; }

    public Severity Severity { get; init; }
}