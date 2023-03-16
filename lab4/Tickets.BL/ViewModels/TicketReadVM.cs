using Tickets.DAL;

namespace Tickets.BL.ViewModels;

public record TicketReadVM(int Id, string Title, string Description, Severity Severity)
{
    public string TitleMarkup => $"<p> {Title} </p>";

}