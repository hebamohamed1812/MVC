using Tickets.DAL;

namespace Tickets;

public interface IDevelopersRepo
{
    IQueryable<Developer> GetAll();
}