using Tickets.BL.ViewModels;

namespace Tickets.BL;

public interface ITicketsManager
{
    TicketDetailsVM? GetTicketDetails(int id);
    TicketEditVM? GetForEdit(int id);
    void Update(TicketEditVM ticketVM);
}
