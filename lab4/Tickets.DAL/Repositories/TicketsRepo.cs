using Microsoft.EntityFrameworkCore;

namespace Tickets.DAL;

public class TicketsRepo : ITicketsRepo
{
    private readonly TicketsContext _context;

    public TicketsRepo(TicketsContext context)
    {
        _context = context;
    }

    public IEnumerable<Ticket> GetAll()
    {
        return _context.Set<Ticket>();
    }

    public Ticket? Get(int id)
    {
        return _context.Set<Ticket>().Find(id);
    }

    public void Add(Ticket ticket)
    {
        _context.Set<Ticket>().Add(ticket);
    }

    public void Update(Ticket ticket)
    {
    }

    public void Delete(int id)
    {
        var ticketToDelete = Get(id);
        if (ticketToDelete != null)
        {
            _context.Set<Ticket>().Remove(ticketToDelete);
        }
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}