using Tickets.DAL;

namespace Tickets;

public class DepartmentsRepo : IDepartmentsRepo
{
    private readonly TicketsContext _context;

    public DepartmentsRepo(TicketsContext context)
    {
        _context = context;
    }

    public IEnumerable<Department> GetAll()
    {
        return _context.Set<Department>();
    }
}
