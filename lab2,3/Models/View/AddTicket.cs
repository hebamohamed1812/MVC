using lab2.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace lab2.Models.View;
public record AddTicket
{
    public string Description { get; init; } = string.Empty;
    [Display(Name = "Is Closed")]
    public bool IsClosed { get; init; }
    public Severity Severity { get; init; }
    [Display(Name = "Department")]
    public Guid DepartmentId { get; init; }
    
    [Display(Name = "Developers")]
    public List<Guid> DevelopersIds { get; init; } = new();
    
}