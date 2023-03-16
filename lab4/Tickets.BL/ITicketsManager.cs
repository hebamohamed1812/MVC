using Tickets.BL.ViewModels;

namespace Tickets.BL;
public interface ITicketsManager
{
    List<TicketReadVM> GetAll();
    TicketReadVM? Get(int id);
    void Add(TicketAddVM ticket);
    void Edit(TicketEditVM ticket);
    void Delete(TicketEditVM ticket);
    int GetRepoHashCode();
}