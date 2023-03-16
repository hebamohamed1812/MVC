using Tickets.DAL;

namespace Tickets.BL.ViewModels;

public record TicketAddVM(string Title, string Description, Severity Severity);
