using System.ComponentModel.DataAnnotations;

namespace Tickets.BL.ViewModels;

public record TicketDetailsVM(
    [Display(Name = "Department's Name")]
    string DepartmentName,
    int DevelopersCount
    );