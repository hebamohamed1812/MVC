using Tickets;
using Tickets.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tickets.BL;

public class DevelopersManager : IDevelopersManager
{
    private readonly IDevelopersRepo _developersRepo;

    public DevelopersManager(IDevelopersRepo developersRepo)
    {
        _developersRepo = developersRepo;
    }
    public IEnumerable<SelectListItem> GetDevelopersListItems()
    {
        IEnumerable<Developer> developersFromDb = _developersRepo.GetAll();
        return developersFromDb.Select(i => new SelectListItem(i.Name, i.Id.ToString()));
    }
}
