using Tickets.BL.ViewModels;
using Tickets.DAL;

namespace Tickets.BL;

public class TicketsManager : ITicketsManager
{
    private readonly ITicketsRepo _ticketsRepo;

    public TicketsManager(ITicketsRepo ticketsRepo)
    {
        _ticketsRepo = ticketsRepo;
    }

    public List<TicketReadVM> GetAll()
    {
        var ticketsFromDB = _ticketsRepo.GetAll();
        return ticketsFromDB.Select(d => new TicketReadVM(d.Id, d.Title, d.Description, d.Severity))
            .ToList();
    }

    public TicketReadVM? Get(int id)
    {
        var ticketFromDB = _ticketsRepo.Get(id);
        if (ticketFromDB == null)
        {
            return null;
        }
        return new TicketReadVM(ticketFromDB.Id, ticketFromDB.Title, ticketFromDB.Description, ticketFromDB.Severity);
    }

    public void Add(TicketAddVM ticketVM)
    {
        var ticket = new Ticket
        {
            Title = ticketVM.Title,
            Description = ticketVM.Description,
            Severity = ticketVM.Severity
        };

        _ticketsRepo.Add(ticket);
        _ticketsRepo.SaveChanges();
    }

    public void Edit(TicketEditVM ticket)
    {
        var ticketToEdit = _ticketsRepo.Get(ticket.Id);

        ticketToEdit.Id = ticket.Id;
        ticketToEdit.Title = ticket.Title;
        ticketToEdit.Description = ticket.Description;
        ticketToEdit.Severity = ticket.Severity;

        _ticketsRepo.SaveChanges();
    }

    public void Delete(TicketEditVM ticket)
    {
        _ticketsRepo.Delete(ticket.Id);
        _ticketsRepo.SaveChanges();

    }

    public int GetRepoHashCode()
    {
        return _ticketsRepo.GetHashCode();   
    }
}
