using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tickets.BL;

public interface IDevelopersManager
{
    IEnumerable<SelectListItem> GetDevelopersListItems();
}
