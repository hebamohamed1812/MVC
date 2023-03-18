using Tickets;
using Tickets.BL.ViewModels;
using Tickets.DAL;

namespace Tickets.BL;

public class TicketsManager : ITicketsManager
{
    private readonly ITicketsRepo _ticketsRepo;
    private readonly IDevelopersRepo _developersRepo;

    public TicketsManager(ITicketsRepo ticketsRepo, IDevelopersRepo developersRepo)
    {
        _ticketsRepo = ticketsRepo;
        _developersRepo = developersRepo;
    }

    public TicketEditVM? GetForEdit(int id)
    {
        Ticket? ticketFromDb = _ticketsRepo.GetPatientWithDeveloper(id);
        if (ticketFromDb is null)
        {
            return null;
        }
        return new TicketEditVM(
            Id: ticketFromDb.Id,
            Title: ticketFromDb.Title,
            DepartmentId: ticketFromDb.DepartmentId,
            DevelopersIds: ticketFromDb.Developers.Select(i => i.Id).ToArray());
    }

    public TicketDetailsVM? GetTicketDetails(int id)
    {
        Ticket? ticketFromDb = _ticketsRepo.GetTicketWithDevelopersAndDepartment(id);
        if (ticketFromDb is null)
        {
            return null;
        }

        return new TicketDetailsVM(
            DepartmentName: ticketFromDb.Department?.Name ?? "",
            DevelopersCount: ticketFromDb.Developers.Count);
    }

    public void Update(TicketEditVM ticketVM)
    {
        Ticket? entityToUpdate = _ticketsRepo.GetPatientWithDeveloper(ticketVM.Id);
        if (entityToUpdate is null)
        {
            return;
        }
        entityToUpdate.Title = ticketVM.Title;
        entityToUpdate.DepartmentId = ticketVM.DepartmentId;
        entityToUpdate.Developers = GetDevelopersByIds(ticketVM.DevelopersIds);
        _ticketsRepo.Update(entityToUpdate);
        _ticketsRepo.Save();
    }

    private ICollection<Developer> GetDevelopersByIds(int[] developersIds)
    {
        var developer = _developersRepo.GetAll();
        return developer.Where(i => developersIds.Contains(i.Id)).ToList();
    }
}
