using Tickets;
using Tickets.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tickets.BL;

public class DepartmentsManager : IDepartmentsManager
{
    private readonly IDepartmentsRepo _departmentsRepo;

    public DepartmentsManager(IDepartmentsRepo departmentsRepo)
    {
        _departmentsRepo = departmentsRepo;
    }

    public IEnumerable<SelectListItem> GetDepartmentsListItems()
    {
        var departmentsFromDb = _departmentsRepo.GetAll();
        return departmentsFromDb.Select(d => new SelectListItem(d.Name, d.Id.ToString()));
    }
}
