using Tickets.DAL;

namespace Tickets.BL.ViewModels;

public record TicketEditVM {
    public int Id { get; init; }
    public string? Title { get; init; }
    public string? Description { get; init; }
    public Severity Severity { get; init; } 
}