using Microsoft.EntityFrameworkCore;

namespace Tickets.DAL;

public class TicketsRepo : ITicketsRepo
{

    private readonly TicketsContext _context;

    public TicketsRepo(TicketsContext context)
    {
        _context = context;
    }

    public Ticket? GetPatientWithDeveloper(int id)
    {
        return _context.Set<Ticket>()
            .Include(p => p.Developers)
            .FirstOrDefault(p => p.Id == id);
    }

    public Ticket? GetTicketWithDevelopersAndDepartment(int id)
    {
        return _context.Set<Ticket>()
            .Include(p => p.Department)
            .Include(p => p.Developers)
            .FirstOrDefault(p => p.Id == id);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Update(Ticket ticket)
    {
    }
}