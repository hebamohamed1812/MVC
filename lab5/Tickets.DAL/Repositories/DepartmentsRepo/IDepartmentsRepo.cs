using Tickets.DAL;

namespace Tickets;

public interface IDepartmentsRepo
{
    IEnumerable<Department> GetAll();
}