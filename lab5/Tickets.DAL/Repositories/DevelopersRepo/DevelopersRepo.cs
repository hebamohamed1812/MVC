using Tickets.DAL;

namespace Tickets;

public class DevelopersRepo : IDevelopersRepo
{
    private readonly TicketsContext _context;

    public DevelopersRepo(TicketsContext coontext)
    {
        _context = coontext;
    }

    public IQueryable<Developer> GetAll()
    {
        return _context.Set<Developer>();
    }
}
