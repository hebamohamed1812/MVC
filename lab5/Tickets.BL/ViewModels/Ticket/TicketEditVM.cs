namespace Tickets.BL.ViewModels;

public record TicketEditVM(int Id,
    string Title,
    int DepartmentId,
    int[] DevelopersIds
    );
