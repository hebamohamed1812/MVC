using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tickets.BL;

public interface IDepartmentsManager
{
    IEnumerable<SelectListItem> GetDepartmentsListItems();
}