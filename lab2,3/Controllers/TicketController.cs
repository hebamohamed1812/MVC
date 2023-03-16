using System.Linq;
using lab2.Models;
using lab2.Models.Domain;
using lab2.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace lab2.Controllers;

public class TicketController : Controller
{
    private static readonly List<Ticket> _tickets = new();
    public IActionResult Index()
    {
        return View(_tickets);
    }

    public IActionResult GetDetails(Guid id)
    {
        return View(_tickets);
    }


    [HttpGet]
    public IActionResult Add()
    {
        GetFormDataReady();
        return View();
    }

    [HttpPost]
    public IActionResult Add(AddTicket ticketVM)
    {
        var developers = Developer.GetDevelopers();
        var selectedDevelopersIds = ticketVM.DevelopersIds;

        var selectedDevelopers = developers
            .Where(a => selectedDevelopersIds.Contains(a.Id))
            .ToList();

        var selectedDeveloperByJoin = (from a in developers
                                   join selectedId in selectedDevelopersIds
                                   on a.Id equals selectedId
                                   select a).ToList();

        Ticket ticket = new Ticket
        {
            Id = Guid.NewGuid(),
            Description = ticketVM.Description,
            Severity = ticketVM.Severity,
            IsClosed = ticketVM.IsClosed,
            Developers = selectedDevelopers,
            Department = Department.GetDepartments().First(c => c.Id == ticketVM.DepartmentId),
        };
        _tickets.Add(ticket);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(Guid id)
    {
        GetFormDataReady();
        var ticketToEdit = _tickets.First(a => a.Id == id);
        var ticket = new EditTicket
        {
            Description = ticketToEdit.Description,
            IsClosed = ticketToEdit.IsClosed,
            Severity = ticketToEdit.Severity,
            DepartmentId = ticketToEdit.Department.Id,
            DevelopersIds = ticketToEdit.Developers.Select(a => a.Id).ToList(),
        };

        return View(ticket);
    }

    [HttpPost]
    public IActionResult Edit(EditTicket ticketVM)
    {
        var selectedDevelopers = GetDevelopresByIds(ticketVM.DevelopersIds);
        var ticketToEdit = _tickets.First(a => a.Id == ticketVM.Id);

        ticketToEdit.Description = ticketVM.Description;
        ticketToEdit.Severity = ticketVM.Severity;
        ticketToEdit.IsClosed = ticketVM.IsClosed;
        ticketToEdit.Department = Department.GetDepartments().First(c => c.Id == ticketVM.DepartmentId);
        ticketToEdit.Developers = selectedDevelopers;

        return RedirectToAction(nameof(Index));
    }
    private void GetFormDataReady()
    {
        var departments = Department.GetDepartments();
        var departmentsList = departments
            .Select(d => new SelectListItem(d.Name, d.Id.ToString()));

        ViewData[MagicStrings.Departments] = departmentsList;

        var developers = Developer.GetDevelopers();
        var developersListItems = developers
        .Select(a => new SelectListItem(a.FirstName, a.Id.ToString()));
        ViewBag.developersListItems = developersListItems;
    }


    private static List<Developer> GetDevelopresByIds(List<Guid> selectedDevelopersIds)
    {
        var developers = Developer.GetDevelopers();
        var selectedDevelopers = developers
            .Where(a => selectedDevelopersIds.Contains(a.Id))
            .ToList();
        return selectedDevelopers;
    }
}
